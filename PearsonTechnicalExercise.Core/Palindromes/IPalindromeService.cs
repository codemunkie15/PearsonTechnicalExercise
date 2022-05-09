namespace PearsonTechnicalExercise.Core.Palindromes
{
    public interface IPalindromeService
    {
        GenericResult<bool> IsPalindrome(string input);
    }
}
