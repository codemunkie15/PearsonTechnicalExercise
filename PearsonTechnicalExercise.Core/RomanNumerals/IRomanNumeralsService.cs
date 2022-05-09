namespace PearsonTechnicalExercise.Core.RomanNumerals
{
    /// <summary>
    /// A service for dealing with roman numerals.
    /// </summary>
    public interface IRomanNumeralsService
    {
        /// <summary>
        /// Gets the roman numeral notation for a given integer.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A <see cref="GenericResult{T}"/> holding the result and any validation errors.</returns>
        GenericResult<string> GetRomanNumerals(string input);
    }
}
