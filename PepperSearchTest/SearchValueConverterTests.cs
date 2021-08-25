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
    public class SearchValueConverterTests
    {
        [TestMethod]
        public void Convert_WhenFirstStringNull_ReturnsFalse()
        {
            // Arrange
            object[] input = { null, "Test123" };
            bool result = false;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenSecondStringNull_ReturnsFalse()
        {
            // Arrange
            object[] input = { "Test123", null };
            bool result = false;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenBothStringsNull_ReturnsFalse()
        {
            // Arrange
            object[] input = { null, null };
            bool result = false;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenFirstStringEmpty_ReturnsFalse()
        {
            // Arrange
            object[] input = { String.Empty, "Test123" };
            bool result = false;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // & Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenSecondStringEmpty_ReturnsFalse()
        {
            // Arrange
            object[] input = { "Test123", String.Empty };
            bool result = false;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // & Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenBothStringsEmpty_ReturnsFalse()
        {
            // Arrange
            object[] input = { String.Empty, String.Empty };
            bool result = false;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // & Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenIsMatch_ReturnsTrue()
        {
            // Arrange
            object[] input = { "Test123", "123" };
            bool result = true;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // & Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenStringsAreTheSame_ReturnTrue()
        {
            // Arrange
            object[] input = { "Test123", "Test123" };
            bool result = true;

            // Act
            bool output = (bool)new SearchValueConverter().Convert(input, null, null, null);

            // & Assert
            Assert.AreEqual(result, output);
        }
    }
}
