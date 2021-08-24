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
    public class StringWhitespaceTests
    {
        [TestMethod]
        public void RemoveWhitespace_WhenStringNull_ThrowsException()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.RemoveWhitespace());
        }
    
        [TestMethod]
        public void RemoveWhitespace_WhenEmptyInput_ReturnsEmptyOutput()
        {
            // Arrange
            string input = String.Empty;
            string result = String.Empty;

            // Act
            string output = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void RemoveWhitespace_WhenWhitespaceFirst()
        {
            // Arrange
            string input = " Test123";
            string result = "Test123";

            // Act
            string output = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void RemoveWhitepace_WhenWhitespaceLast()
        {
            // Arrange
            string input = "Test123 ";
            string result = "Test123";

            // Act
            string output = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void RemoveWhitepace_WhenWhitespaceInMiddle()
        {
            // Arrange
            string input = "Tes t123";
            string result = "Test123";

            // Act
            string output = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void RemoveWhitespace_WhenMultipleWhitespace()
        {
            // Arrange
            string input = "Tes t12 3";
            string result = "Test123";

            // Act
            string output = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(result, output);
        }
    }
}
