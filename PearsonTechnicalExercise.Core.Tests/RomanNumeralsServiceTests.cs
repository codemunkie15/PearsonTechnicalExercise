using Microsoft.VisualStudio.TestTools.UnitTesting;
using PearsonTechnicalExercise.Core.RomanNumerals;
using System.Linq;

namespace PearsonTechnicalExercise.Core.Tests
{
    [TestClass]
    public class RomanNumeralsServiceTests
    {
        private readonly RomanNumeralsService romanNumeralsService = new();

        [TestMethod]
        public void GetRomanNumerals_ReturnsError_IfEmpty()
        {
            var result = romanNumeralsService.GetRomanNumerals("");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsError_IfNotNumber()
        {
            var result = romanNumeralsService.GetRomanNumerals("test");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsError_IfNumberIsNegative()
        {
            var result = romanNumeralsService.GetRomanNumerals("-5");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsError_IfNumberGreaterThan3999()
        {
            var result = romanNumeralsService.GetRomanNumerals("4006");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsCorrectValue_39()
        {
            var result = romanNumeralsService.GetRomanNumerals("39");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, "XXXIX");
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsCorrectValue_246()
        {
            var result = romanNumeralsService.GetRomanNumerals("246");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, "CCXLVI");
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsCorrectValue_789()
        {
            var result = romanNumeralsService.GetRomanNumerals("789");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, "DCCLXXXIX");
        }

        [TestMethod]
        public void GetRomanNumerals_ReturnsCorrectValue_2421()
        {
            var result = romanNumeralsService.GetRomanNumerals("2421");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, "MMCDXXI");
        }
    }
}
