using Microsoft.Extensions.DependencyInjection;
using PearsonTechnicalExercise.Core.CoinChange;
using PearsonTechnicalExercise.Core.Fibonacci;
using PearsonTechnicalExercise.Core.Palindromes;
using PearsonTechnicalExercise.Core.RomanNumerals;

namespace PearsonTechnicalExercise.Core
{
    public static class Registration
    {
        public static IServiceCollection UsePearsonTechnicalExerciseCore(this IServiceCollection services)
        {
            return services
                .AddScoped<IPalindromeService, PalindromeService>()
                .AddScoped<IRomanNumeralsService, RomanNumeralsService>()
                .AddScoped<ICoinChangeService, CoinChangeService>()
                .AddScoped<IFibonacciService, FibonacciService>();
        }
    }
}