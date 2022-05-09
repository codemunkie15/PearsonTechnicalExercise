using Microsoft.VisualStudio.TestTools.UnitTesting;
using PearsonTechnicalExercise.Core.Palindromes;
using System.Linq;

namespace PearsonTechnicalExercise.Core.Tests
{
    [TestClass]
    public class PalindromeServiceTests
    {
        private readonly PalindromeService palindromeService = new();

        [TestMethod]
        public void IsPalindrome_IsSuccessful_Racecar()
        {
            var result = palindromeService.IsPalindrome("Racecar");
            Assert.IsTrue(result.IsSuccessful);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsTrue_Racecar()
        {
            var result = palindromeService.IsPalindrome("Racecar");
            Assert.AreEqual(result.Value, true);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsTrue_noon()
        {
            var result = palindromeService.IsPalindrome("noon");
            Assert.AreEqual(result.Value, true);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsFalse_test()
        {
            var result = palindromeService.IsPalindrome("test");
            Assert.AreEqual(result.Value, false);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsError_IfEmpty()
        {
            var result = palindromeService.IsPalindrome("");
            Assert.IsTrue(result.Errors.Any());
            Assert.IsFalse(result.IsSuccessful);
        }
    }
}