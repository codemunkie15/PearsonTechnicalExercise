namespace PearsonTechnicalExercise.Core.Fibonacci
{
    internal class FibonacciService : IFibonacciService
    {
        public GenericResult<int> GetFibonacciSum(string numberString)
        {
            if (!int.TryParse(numberString, out var n))
            {
                return GenericResult<int>.Fail("Please enter a number.");
            }

            if (n < 1)
            {
                return GenericResult<int>.Success(0);
            }

            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += GetNthFibonacciNumber(i);
            }
            
            return GenericResult<int>.Success(sum);
        }

        private int GetNthFibonacciNumber(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return GetNthFibonacciNumber(n - 1) + GetNthFibonacciNumber(n - 2);
        }
    }
}
