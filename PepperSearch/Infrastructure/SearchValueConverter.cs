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
            string inputText = values[0] == null ? String.Empty: values[0].ToString();
            string textToFind = values[1] as string;

            if (CheckIfStringsAreValid(inputText, textToFind))
            {
                return CheckIfInputContainsText(inputText, textToFind);
            }

            return false;
        }

        private bool CheckIfStringsAreValid(string inputText, string textToFind)
        {
            if (String.IsNullOrEmpty(inputText) || String.IsNullOrEmpty(textToFind))
            {
                return false;
            }

            return true;
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
