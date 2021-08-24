using Microsoft.VisualStudio.TestTools.UnitTesting;
using PepperSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperSearchTest
{
    [TestClass]
    public class PriceConverterTests
    {
        [TestMethod]
        public void ConvertPrice_WhenInputNull_ThrowsException()
        {
            // Arrange
            string input = null;
            string currencySymbol = "zł";
            string groupSymbol = ".";
            string decimalSymbol = ",";

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new PriceConverter(currencySymbol, groupSymbol, decimalSymbol).ConvertPrice(input));
        }
        
        [TestMethod]
        public void ConvertPrice_WhenInputEmpty_ThrowsException()
        {
            // Arrange
            string input = String.Empty;
            string currencySymbol = "zł";
            string groupSymbol = ".";
            string decimalSymbol = ",";

            // Act & Assert
            Assert.ThrowsException<FormatException>(
                () => new PriceConverter(currencySymbol, groupSymbol, decimalSymbol).ConvertPrice(input));
        }

        [TestMethod]
        public void ConvertPrice_WhenInputValid()
        {
            // Arrange
            string input = "230.123,21zł";
            decimal result = 230123.21m;
            string currencySymbol = "zł";
            string groupSymbol = ".";
            string decimalSymbol = ",";

            // Act
            decimal output = new PriceConverter(currencySymbol, groupSymbol, decimalSymbol).ConvertPrice(input);

            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void ConvertPrice_WhenInputWithoutThousands()
        {
            // Arrange
            string input = "123,21zł";
            decimal result = 123.21m;
            string currencySymbol = "zł";
            string groupSymbol = ".";
            string decimalSymbol = ",";

            // Act
            decimal output = new PriceConverter(currencySymbol, groupSymbol, decimalSymbol).ConvertPrice(input);

            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void ConvertPrice_WhenInputWithoutDecimals()
        {
            // Arrange
            string input = "230.123zł";
            decimal result = 230123m;
            string currencySymbol = "zł";
            string groupSymbol = ".";
            string decimalSymbol = ",";

            // Act
            decimal output = new PriceConverter(currencySymbol, groupSymbol, decimalSymbol).ConvertPrice(input);

            Assert.AreEqual(result, output);
        }

        // without decimal
    }
}
