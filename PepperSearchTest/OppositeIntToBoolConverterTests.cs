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
    public class OppositeIntToBoolConverterTests
    {
        [TestMethod]
        public void Convert_WhenInputIsPositiveNumber_ReturnsFalse()
        {
            // Arrange
            int input = 25;
            bool result = false;

            // Act
            bool output = (bool)new OppositeIntToBoolConverter().Convert(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenInputIsNegativeNumber_ReturnsFalse()
        {
            // Arrange
            int input = -25;
            bool result = false;

            // Act
            bool output = (bool)new OppositeIntToBoolConverter().Convert(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenInputIsZero_ReturnTrue()
        {
            // Arrange
            int input = 0;
            bool result = true;

            // Act
            bool output = (bool) new OppositeIntToBoolConverter().Convert(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void ConvertBack_WhenInputIsTrue_ReturnsZero()
        {
            // Arrange
            bool input = true;

            // Act 
            int output = (int)new OppositeIntToBoolConverter().ConvertBack(input, null, null, null);

            // Assert
            Assert.AreEqual(true, output == 0);
        }

        [TestMethod]
        public void ConvertBack_WhenInputIsFalse_ReturnsNotZero()
        {
            // Arrange
            bool input = false;

            // Act 
            int output = (int)new OppositeIntToBoolConverter().ConvertBack(input, null, null, null);

            // Assert
            Assert.AreEqual(true, output != 0);
        }
    }

}
