using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PearsonTechnicalExercise.Core;
using PearsonTechnicalExercise.Core.CoinChange;
using PearsonTechnicalExercise.Core.Fibonacci;
using PearsonTechnicalExercise.Core.Palindromes;
using PearsonTechnicalExercise.Core.RomanNumerals;

namespace PearsonTechnicalExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.UsePearsonTechnicalExerciseCore();
                })
                .Build();

            Console.WriteLine("Pearson Technical Exercise");
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Palindromes");
            Console.WriteLine("2. Romans");
            Console.WriteLine("3. Fibonacci");
            Console.WriteLine("4. Coin Change");
            Console.WriteLine("5. Exit");

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Please choose an option: ");
                    var option = Console.ReadLine();
                    Console.WriteLine();

                    switch (option)
                    {
                        case "1":
                            var palindromesService = host.Services.GetRequiredService<IPalindromeService>();
                            RunPalindromes(palindromesService);
                            break;
                        case "2":
                            var romansService = host.Services.GetRequiredService<IRomanNumeralsService>();
                            RunRomans(romansService);
                            break;
                        case "3":
                            var fibonacciService = host.Services.GetRequiredService<IFibonacciService>();
                            RunFibonacci(fibonacciService);
                            break;
                        case "4":
                            var coinChangeService = host.Services.GetRequiredService<ICoinChangeService>();
                            RunCoinChange(coinChangeService);
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine($"{option} is not a valid option.");
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error was thrown: {ex.Message}");
                }
            }
        }

        private static void RunPalindromes(IPalindromeService service)
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            var result = service.IsPalindrome(input);
            if (result.IsSuccessful)
            {
                Console.WriteLine($"{input} {(result.Value ? "is" : "is not")} a palindrome.");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private static void RunRomans(IRomanNumeralsService service)
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            var result = service.GetRomanNumerals(input);
            if (result.IsSuccessful)
            {
                Console.WriteLine($"Roman numerals: {result.Value}");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private static void RunFibonacci(IFibonacciService service)
        {
            Console.Write("Enter n: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            var result = service.GetFibonacciSum(input);
            if (result.IsSuccessful)
            {
                Console.WriteLine($"Fibonacci sum: {result.Value}");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private static void RunCoinChange(ICoinChangeService service)
        {
            Console.Write("Enter a number in pence: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            var result = service.GetCoinChange(input);
            if (result.IsSuccessful)
            {
                Console.WriteLine($"Coin change:");
                foreach (var kvp in result.Value)
                {
                    Console.WriteLine($"{kvp.Value} x {kvp.Key}p");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}