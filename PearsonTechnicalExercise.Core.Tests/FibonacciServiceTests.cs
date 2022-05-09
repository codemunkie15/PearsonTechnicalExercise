using Microsoft.VisualStudio.TestTools.UnitTesting;
using PearsonTechnicalExercise.Core.Fibonacci;
using System.Linq;

namespace PearsonTechnicalExercise.Core.Tests
{
    [TestClass]
    public class FibonacciServiceTests
    {
        private readonly FibonacciService fibonacciService = new();

        [TestMethod]
        public void GetFibonacciSum_ReturnsError_IfEmpty()
        {
            var result = fibonacciService.GetFibonacciSum("");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void GetFibonacciSum_Returns0_NLessThanOne()
        {
            var result = fibonacciService.GetFibonacciSum("-1");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, 0);
        }

        [TestMethod]
        public void GetFibonacciSum_ReturnsCorrectValue_5()
        {
            var result = fibonacciService.GetFibonacciSum("5");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, 7);
        }

        [TestMethod]
        public void GetFibonacciSum_ReturnsCorrectValue_8()
        {
            var result = fibonacciService.GetFibonacciSum("8");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Value, 33);
        }
    }
}
