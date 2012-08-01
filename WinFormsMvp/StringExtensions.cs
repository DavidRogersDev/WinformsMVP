using System;

namespace WinFormsMvp
{
    internal static class StringExtensions
    {
        internal static string TrimFromEnd(this string source, string suffix)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(suffix))
                return source;
            var length = source.LastIndexOf(suffix, StringComparison.OrdinalIgnoreCase);
            return length > 0 ? source.Substring(0, length) : source;
        }
    }
}
