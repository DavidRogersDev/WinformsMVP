using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;
using WinFormsMvp;

namespace WinFormsMvp.UnitTests
{

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///This is an exact copy of the CollectionExtensionsTests from the original WebFormsMVP project (thanks guys!)
    ///</summary>
    [TestClass()]
    public class CollectionExtensionsTests
    {
        [TestMethod]
        public void CollectionExtensions_ICollection_AddRange_AddsItemsToInstance()
        {
            // Arrange
            ICollection<string> actual = new List<string> { "1", "2", "3" };

            // Act
            actual.AddRange(new[] { "4", "5" });

            // Assert
            var expecting = new List<string> { "1", "2", "3", "4", "5" };
            CollectionAssert.AreEqual(expecting, (List<string>)actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionExtensions_ICollection_AddRange_ThrowsIfTargetArgumentIsNull()
        {
            // Arrange
            ICollection<string> actual = null;

            // Act
            actual.AddRange(new[] { "1", "2" });

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionExtensions_ICollection_AddRange_ThrowsIfListArgumentIsNull()
        {
            // Arrange
            ICollection<string> actual = new List<string> { "1", "2", "3" };

            // Act
            actual.AddRange(null);

            // Assert
        }

        [TestMethod]
        public void CollectionExtensions_IDictionary_GetOrCreateValue_GetsValueIfContainedInDictionary()
        {
            // Arrange
            IDictionary<string, string> dictionary = new Dictionary<string, string> { { "blah", "value" } };

            // Act
            // ReSharper disable InvokeAsExtensionMethod
            var result = CollectionExtensions.GetOrCreateValue(dictionary, "blah", () => "yo");
            // ReSharper restore InvokeAsExtensionMethod

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void CollectionExtensions_IDictionary_GetOrCreateValue_AddsValueIfNotContainedInDictionary()
        {
            // Arrange
            IDictionary<string, string> dictionary = new Dictionary<string, string>();

            // Act
            var result = dictionary.GetOrCreateValue("blah", () => "yo");

            // Assert
            Assert.AreEqual("yo", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionExtensions_IDictionary_GetOrCreateValue_ThrowsIfDictionaryArgumentIsNull()
        {
            // Arrange

            // Act
            ((IDictionary<string, string>)null).GetOrCreateValue("blah", () => "yo");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionExtensions_IEnumerable_ToDictionary_ThrowsIfSourceArgumentIsNull()
        {
            // Arrange

            // Act
            ((IEnumerable<KeyValuePair<string, string>>)null).ToDictionary();

            // Assert
        }

        [TestMethod]
        public void CollectionExtensions_IEnumerable_ToDictionary_ReturnsItemsAsDictionary()
        {
            // Arrange
            var source = new[]
                         {
                             new KeyValuePair<int, string>(1, "1"),
                             new KeyValuePair<int, string>(2, "2"),
                             new KeyValuePair<int, string>(3, "3"),
                             new KeyValuePair<int, string>(4, "4"),
                         };

            // Act
            var result = source.ToDictionary();

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, (ICollection)result.Keys);
            CollectionAssert.AreEqual(new[] { "1", "2", "3", "4" }, (ICollection)result.Values);
        }
    }
}
