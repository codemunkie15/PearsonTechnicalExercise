using Microsoft.VisualStudio.TestTools.UnitTesting;
using PearsonTechnicalExercise.Core.CoinChange;
using System.Collections.Generic;
using System.Linq;

namespace PearsonTechnicalExercise.Core.Tests
{
    [TestClass]
    public class CoinChangeServiceTests
    {
        private readonly CoinChangeService coinChangeService = new();

        [TestMethod]
        public void GetCoinChange_ReturnsError_IfEmpty()
        {
            var result = coinChangeService.GetCoinChange("");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetCoinChange_ReturnsError_IfNotNumber()
        {
            var result = coinChangeService.GetCoinChange("test");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetCoinChange_ReturnsError_IfPenceBelow0()
        {
            var result = coinChangeService.GetCoinChange("-1");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetCoinChange_ReturnsCorrectResult_53()
        {
            var result = coinChangeService.GetCoinChange("53");
            var expectedValue = new Dictionary<int, int>
            {
                { 50, 1 },
                { 2, 1 },
                { 1, 1 }
            };

            Assert.IsTrue(result.IsSuccessful);
            CollectionAssert.AreEquivalent(result.Value.ToList(), expectedValue);
        }

        [TestMethod]
        public void GetCoinChange_ReturnsCorrectResult_239()
        {
            var result = coinChangeService.GetCoinChange("239");
            var expectedValue = new Dictionary<int, int>
            {
                { 100, 2 },
                { 20, 1 },
                { 10, 1 },
                { 5, 1 },
                { 2, 2 },
            };

            Assert.IsTrue(result.IsSuccessful);
            CollectionAssert.AreEquivalent(result.Value.ToList(), expectedValue);
        }
    }
}