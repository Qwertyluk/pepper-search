using Microsoft.VisualStudio.TestTools.UnitTesting;
using PepperSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PepperSearchTest
{
    [TestClass]
    public class PepperGroupConverterTests
    {
        [TestMethod]
        public void Convert_WhenInputEqualasParameter_ReturnsTrue()
        {
            // Arrange
            PepperGroup input = PepperGroup.All;
            PepperGroup parameter = PepperGroup.All;
            bool result = true;

            // Act
            bool output = (bool)new PepperGroupConverter().Convert(input, null, parameter, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void Convert_WhenInputNotEqualsParameter_ReturnsFalse()
        {
            // Arrange
            PepperGroup input = PepperGroup.All;
            PepperGroup parameter = PepperGroup.Culture;
            bool result = false;

            // Act
            bool output = (bool)new PepperGroupConverter().Convert(input, null, parameter, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void ConvertBack_WhenInputTrue_ReturnsParameter()
        {
            // Arrange
            bool input = true;
            PepperGroup parameter = PepperGroup.All;
            PepperGroup result = PepperGroup.All;

            // Act
            PepperGroup output = (PepperGroup)new PepperGroupConverter().ConvertBack(input, null, parameter, null);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void ConvertBack_WhenInputFalse_ReturnsBindingDoNothing()
        {
            // Arrange
            bool input = false;
            object result = Binding.DoNothing;

            // Act
            object output = new PepperGroupConverter().ConvertBack(input, null, null, null);

            // Assert
            Assert.AreEqual(result, output);
        }
    }
}
