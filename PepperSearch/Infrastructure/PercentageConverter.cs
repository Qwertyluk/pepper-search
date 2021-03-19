using System;

namespace PepperSearch
{
    /// <summary>
    /// Converts percentage values.
    /// </summary>
    public class PercentageConverter
    {
        /// <summary>
        /// Converts string percentage value to decimal value.
        /// </summary>
        /// <param name="input">A string representation</param>
        /// <param name="place">Indicates whether the percentage sign is at the beginning or end of provided string.</param>
        /// <returns></returns>
        public decimal Convert(string input, PercentagePlace place)
        {
            if (place == PercentagePlace.StartsWith)
                return Decimal.Parse(input.TrimStart(new char[] { '%', ' ' })) / 100M;
            else
                return Decimal.Parse(input.TrimEnd(new char[] { '%', ' ' })) / 100M;
        }
    }

    /// <summary>
    /// Indicates the position of the percentage sign in the string.
    /// </summary>
    public enum PercentagePlace
    {
        StartsWith,
        EndsWith
    }
}
