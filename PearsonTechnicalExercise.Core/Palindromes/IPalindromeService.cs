namespace PearsonTechnicalExercise.Core.Palindromes
{
    /// <summary>
    /// A service for dealing with palindromes.
    /// </summary>
    public interface IPalindromeService
    {
        /// <summary>
        /// Checks if the given <paramref name="input"/> is a palindrome.
        /// </summary>
        /// <param name="input">The input to check.</param>
        /// <returns>A <see cref="GenericResult{T}"/> holding the result and any validation errors.</returns>
        GenericResult<bool> IsPalindrome(string input);
    }
}
