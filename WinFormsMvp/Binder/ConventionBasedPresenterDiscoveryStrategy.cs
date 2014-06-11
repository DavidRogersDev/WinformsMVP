using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WinFormsMvp.Binder
{
    /// <summary>
    /// Attempts to find a presenter for a view type based on a set of naming formats conventions.
    /// To use custom naming formats, derive from this class and override the CandidatePresenterTypeFullNameFormats property.
    /// </summary>
    public class ConventionBasedPresenterDiscoveryStrategy : IPresenterDiscoveryStrategy
    {

        ///<summary>
        /// Creates a new instance of the ConventionBasedPresenterDiscoveryStrategy class.
        ///</summary>
        public ConventionBasedPresenterDiscoveryStrategy()
        {

        }

        public virtual PresenterDiscoveryResult GetBinding(IView viewInstance)
        {
            if (viewInstance == null)
                throw new ArgumentNullException("viewInstance");

            return GetBinding(viewInstance, ViewInstanceSuffixes, CandidatePresenterTypeFullNameFormats);
        }

        static readonly IEnumerable<string> defaultViewInstanceSuffixes =
            new[]
            {
                "UserControl",
                "Control",
                "View",
                "Form",
            }; 

        /// <summary>
        /// Override this property to extend the list of suffixes that are automatically stripped from view instances when generating presenter type name candidates.
        /// </summary>
        protected virtual IEnumerable<string> ViewInstanceSuffixes
        {
            get { return defaultViewInstanceSuffixes; }
        }

        // The order of these format strings is important as we yield return to facilitate short circuiting
        // the enumerator as soon as we find a matching type name. The list should be ordered such that the most
        // commonly used naming pattern is at the top and the least used at the bottom.
        static readonly IEnumerable<string> defaultCandidatePresenterTypeFullNameFormats =
            new[]
            {
                "{namespace}.Logic.Presenters.{presenter}",
                "{namespace}.Presenters.{presenter}",
                "{namespace}.Logic.{presenter}",
                "{namespace}.{presenter}"
            };

        /// <summary>
        /// Override this property to extend the list of format strings used to generate candidate names for presenter types.
        /// </summary>
        public virtual IEnumerable<string> CandidatePresenterTypeFullNameFormats
        {
            get { return defaultCandidatePresenterTypeFullNameFormats; }
        }

        static readonly IDictionary<RuntimeTypeHandle, ConventionSearchResult> viewTypeToPresenterTypeCache = new Dictionary<RuntimeTypeHandle, ConventionSearchResult>();

        internal static PresenterDiscoveryResult GetBinding(IView viewInstance, IEnumerable<string> viewInstanceSuffixes, IEnumerable<string> presenterTypeFullNameFormats)
        {
            var viewType = viewInstance.GetType();

            var searchResult = viewTypeToPresenterTypeCache.GetOrCreateValue(viewType.TypeHandle, () =>
                PerformSearch(viewInstance, viewInstanceSuffixes, presenterTypeFullNameFormats));

            return new PresenterDiscoveryResult(
                new[] { viewInstance },
                searchResult.Message,
                searchResult.PresenterType == null
                    ? new PresenterBinding[0]
                    : new[] { new PresenterBinding(searchResult.PresenterType, viewType, viewInstance) }
            );
        }

        static ConventionSearchResult PerformSearch(IView viewInstance, IEnumerable<string> viewInstanceSuffixes, IEnumerable<string> presenterTypeFullNameFormats)
        {
            var viewType = viewInstance.GetType();
            var presenterType = default(Type);


            // Get presenter type name from view instance type name
            var presenterTypeName = new List<string> { GetPresenterTypeNameFromViewTypeName(viewType, viewInstanceSuffixes) };

            // Get presenter type name from implemented IView interface
            presenterTypeName.AddRange(GetPresenterTypeNamesFromViewInterfaceTypeNames(viewType.GetViewInterfaces()));

            // Create candidate presenter type full name
            var candidatePresenterTypeFullNames = GenerateCandidatePresenterTypeFullNames(viewType, presenterTypeName, presenterTypeFullNameFormats);

            // Ask the build manager to load each type until one is found
            var messages = new List<string>();

            

            foreach (var typeFullName in candidatePresenterTypeFullNames.Distinct())
            {
                presenterType = viewType.Assembly.GetType(typeFullName);

                if (presenterType == null)
                {
                    messages.Add(string.Format(
                        CultureInfo.InvariantCulture,
                        "could not find a presenter with type name {0}",
                        typeFullName
                    ));
                    continue;
                }

                if (!typeof(IPresenter).IsAssignableFrom(presenterType))
                {
                    messages.Add(string.Format(
                        CultureInfo.InvariantCulture,
                        "found, but ignored, potential presenter with type name {0} because it does not implement IPresenter",
                        typeFullName
                    ));
                    presenterType = null;
                    continue;
                }

                messages.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "found presenter with type name {0}",
                    typeFullName
                ));
                break;
            }

            return new ConventionSearchResult(
                "ConventionBasedPresenterDiscoveryStrategy:\r\n" +
                    string.Join("\r\n", messages.Select(m => "- " + m).ToArray()),
                presenterType
            );
        }

        /// <summary>
        /// We are only interested in the custom interface which we created for our view. This method carves out the two infrastructure-related
        /// interfaces i.e. IView and IView`1
        /// </summary>
        /// <param name="viewInterfaces">The interfaces identified as relevant to this request.</param>
        /// <returns>Bunch of strings with potential Presenter Type names for the Presenter to bind to.</returns>
        internal static IEnumerable<string> GetPresenterTypeNamesFromViewInterfaceTypeNames(IEnumerable<Type> viewInterfaces)
        {
            // Trim the "I" and "View" from the start & end respectively of the interface names
            return viewInterfaces
                .Where(i => i.Name != "IView" && i.Name != "IView`1") 
                .Select(i => i.Name.TrimStart('I').TrimFromEnd("View"));
        }

        internal static string GetPresenterTypeNameFromViewTypeName(Type viewType, IEnumerable<string> viewInstanceSuffixes)
        {
            // Check for existance of supported suffixes and if found, remove and use result as basis for presenter type name
            // e.g. HelloWorldControl => HelloWorldPresenter
            var presenterTypeName = (from suffix in viewInstanceSuffixes
                                     where viewType.Name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)
                                     select viewType.Name.TrimFromEnd(suffix))
                                     .FirstOrDefault();
            return (string.IsNullOrEmpty(presenterTypeName) ? viewType.Name : presenterTypeName) + "Presenter";
        }

        static IEnumerable<string> GenerateCandidatePresenterTypeFullNames(Type viewType, IEnumerable<string> presenterTypeNames, IEnumerable<string> presenterTypeFullNameFormats)
        {
            // We assume the assembly name is the same as the namespace
            var assemblyName = viewType.Assembly.GetNameSafe();

            foreach (var presenterTypeName in presenterTypeNames)
            {
                // Same location as view instance, e.g. MyApp.Web.Controls.HelloWorldControl => MyApp.Web.Controls.HelloWorldPresenter
                yield return viewType.Namespace + "." + presenterTypeName;

                foreach (var typeNameFormat in presenterTypeFullNameFormats)
                {
                    yield return typeNameFormat.Replace("{namespace}", assemblyName)
                                               .Replace("{presenter}", presenterTypeName);
                }
            }
        }

        class ConventionSearchResult
        {
            readonly string message;
            readonly Type presenterType;

            public ConventionSearchResult(string message, Type presenterType)
            {
                this.message = message;
                this.presenterType = presenterType;
            }

            public string Message { get { return message; } }
            public Type PresenterType { get { return presenterType; } }
        }
    }
}