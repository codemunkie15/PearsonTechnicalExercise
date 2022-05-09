namespace PearsonTechnicalExercise.Core.RomanNumerals
{
    public interface IRomanNumeralsService
    {
        GenericResult<string> GetRomanNumerals(string input);
    }
}
