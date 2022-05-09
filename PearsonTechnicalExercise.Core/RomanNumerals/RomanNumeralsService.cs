using System.Text;
using System.Text.RegularExpressions;

namespace PearsonTechnicalExercise.Core.RomanNumerals
{
    internal class RomanNumeralsService : IRomanNumeralsService
    {
        private readonly Dictionary<int, string> romanNumeralRules = new()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" }
        };

        private const string ConsecutiveCharactersRegex = @"(.)\1{3,}";

        public GenericResult<string> GetRomanNumerals(string inputString)
        {
            if (!int.TryParse(inputString, out var input))
            {
                return GenericResult<string>.Fail("Please enter a number.");
            }

            if (input < 1 || input > 3999)
            {
                return GenericResult<string>.Fail("Please enter a number between 1 and 3,999.");
            }


            var romanNumerals = new List<string>();

            var placeFactor = 1;
            foreach (var number in input.ToString().Reverse().Select(c => Convert.ToInt32(c.ToString())))
            {
                var numberPlace = number * placeFactor;

                // Try using addative numerals first
                var placeRomanNumerals = GetAdditiveRomanNumerals(numberPlace);
                // If there are more than 3 consecutive characters use subtractive numerals instead
                if (Regex.IsMatch(placeRomanNumerals, ConsecutiveCharactersRegex))
                {
                    placeRomanNumerals = GetSubtractiveRomanNumerals(numberPlace);
                }

                romanNumerals.Add(placeRomanNumerals);
                placeFactor *= 10;
            }

            var finalRomanNumerals = string.Join("", romanNumerals.AsEnumerable().Reverse());
            return GenericResult<string>.Success(finalRomanNumerals);
        }

        private string GetAdditiveRomanNumerals(int number)
        {
            var romanNumeralString = new StringBuilder();

            foreach (var kvp in romanNumeralRules.OrderByDescending(kvp => kvp.Key))
            {
                while (number >= kvp.Key)
                {
                    romanNumeralString.Append(kvp.Value);
                    number -= kvp.Key;
                }
            }

            return romanNumeralString.ToString();
        }

        private string GetSubtractiveRomanNumerals(int number)
        {
            var romanNumeralString = new StringBuilder();

            while (number > 0)
            {
                foreach (var kvp in romanNumeralRules.OrderBy(kvp => kvp.Key))
                {
                    if (kvp.Key >= number)
                    {
                        romanNumeralString.Append(kvp.Value);
                        number = kvp.Key - number;
                        break; // Restarts the romanNumeralRules foreach
                    }
                }
            }

            return new string(romanNumeralString.ToString().Reverse().ToArray());
        }
    }
}
