using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// Class that works with whitespace in strings.
    /// </summary>
    public static class StringWhitespace
    {
        /// <summary>
        /// Removes all whitespace from the string.
        /// </summary>
        /// <param name="input">A string inside which all white space will be removed</param>
        /// <returns>A string without whitespace.</returns>
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }
    }
}
