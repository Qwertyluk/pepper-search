using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PepperSearch
{
    public class SearchValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VerifyValues(values);

            string inputText = values[0].ToString();
            string textToFind = (string)values[1];

            if (!CheckIfStringsAreEmpty(inputText, textToFind))
            {
                return CheckIfInputContainsText(inputText, textToFind);
            }

            return false;
        }

        private void VerifyValues(object[] values)
        {
            if (CheckIfValuesAreNull(values))
            {
                throw new ArgumentNullException("values");
            }
        }

        private bool CheckIfValuesAreNull(object[] values)
        {
            if (values == null || values[0] == null || values[1] == null)
            {
                return true;
            }

            return false;
        }

        private bool CheckIfStringsAreEmpty(string inputText, string textToFind)
        {
            if (inputText == String.Empty || textToFind == String.Empty)
            {
                return true;
            }

            return false;
        }

        private bool CheckIfInputContainsText(string inputText, string textToFind)
        {
            return inputText.ToLower().Contains(textToFind.ToLower());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
