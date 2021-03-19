using System;
using System.Globalization;

namespace PepperSearch
{
    /// <summary>
    /// Class represents a price converter.
    /// </summary>
    public class PriceConverter : IPriceConvertion
    {
        /// <summary>
        /// Converts a price from a string type to a decimal type.
        /// </summary>
        /// <param name="price">The price to be converted.</param>
        /// <returns>Decimal value of the price.</returns>
        public decimal ConvertPrice(string price)
        {
            NumberFormatInfo formatInfo = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatInfo.CurrencySymbol = "zł";
            formatInfo.CurrencyGroupSeparator = ".";
            formatInfo.CurrencyDecimalSeparator = ",";
            formatInfo.NumberGroupSeparator = ".";
            formatInfo.NumberDecimalSeparator = ",";
            decimal ret;
            try
            {
                ret = Decimal.Parse(price, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, formatInfo);
            }
            catch (FormatException ex)
            {
                throw ex;
            }

            return ret;
        }
    }
}
