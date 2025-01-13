using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject1.Services;

namespace MyWebApp.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private CalculatorService _calculatorService;

        [TestInitialize]
        public void Setup()
        {
            _calculatorService = new CalculatorService();
        }

        [TestMethod]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            int a = 5, b = 3;

            // Act
            var result = _calculatorService.Add(a, b);

            // Assert
            Assert.AreEqual(8, result, "The addition result should be 8.");
        }

        [TestMethod]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            // Arrange
            int a = 5, b = 3;

            // Act
            var result = _calculatorService.Subtract(a, b);

            // Assert
            Assert.AreEqual(2, result, "The subtraction result should be 2.");
        }
    }
}
