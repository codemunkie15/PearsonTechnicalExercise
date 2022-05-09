namespace PearsonTechnicalExercise.Core.Palindromes
{
    /// <summary>
    /// A service for dealing with palindromes.
    /// </summary>
    internal class PalindromeService : IPalindromeService
    {
        /// <inheritdoc/>
        public GenericResult<bool> IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return GenericResult<bool>.Fail("Please enter a value.");
            }

            var reverse = new string(input.Reverse().ToArray());
            var result = input.Equals(reverse, StringComparison.InvariantCultureIgnoreCase);
            return GenericResult<bool>.Success(result);
        }
    }
}
