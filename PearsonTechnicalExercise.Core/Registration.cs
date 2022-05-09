using Microsoft.Extensions.DependencyInjection;
using PearsonTechnicalExercise.Core.CoinChange;
using PearsonTechnicalExercise.Core.Fibonacci;
using PearsonTechnicalExercise.Core.Palindromes;
using PearsonTechnicalExercise.Core.RomanNumerals;

namespace PearsonTechnicalExercise.Core
{
    /// <summary>
    /// Provides extension methods for registering the required dependencies for the Pearson Technical Exercise.
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// Registers the required dependencies for the Pearson Technical Exercise.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The registered service collection.</returns>
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