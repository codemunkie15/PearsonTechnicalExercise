namespace PearsonTechnicalExercise.Core.Fibonacci
{
    /// <summary>
    /// A service for dealing with fibonacci numbers.
    /// </summary>
    public interface IFibonacciService
    {
        /// <summary>
        /// Gets the sum of all the fibonacci numbers up to but not including <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The nth fibonacci number.</param>
        /// <returns>A <see cref="GenericResult{T}"/> holding the result and any validation errors.</returns>
        GenericResult<int> GetFibonacciSum(string n);
    }
}
