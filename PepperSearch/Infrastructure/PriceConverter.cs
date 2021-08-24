using System;
using System.Globalization;

namespace PepperSearch
{
    public class PriceConverter : IPriceConvertion
    {
        private NumberFormatInfo numberFormatInfo;

        public PriceConverter(string currencySymbol, string numberGroupSeparator, string numberDecimalSeparator)
        {
            InitializeNumberFormatInfo(currencySymbol, numberGroupSeparator, numberDecimalSeparator);
        }

        private void InitializeNumberFormatInfo(string currencySymbol, string numberGroupSeparator, string numberDecimalSeparator)
        {
            this.numberFormatInfo = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            this.numberFormatInfo.CurrencySymbol = currencySymbol;
            this.numberFormatInfo.NumberGroupSeparator = numberGroupSeparator;
            this.numberFormatInfo.NumberDecimalSeparator = numberDecimalSeparator;
        }

        public decimal ConvertPrice(string price)
        {
            return TryToParseDecimal(price);
        }

        private decimal TryToParseDecimal(string stringToParse)
        {
            try
            {
                return Decimal.Parse(stringToParse, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, this.numberFormatInfo);
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
    }
}
