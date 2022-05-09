namespace PearsonTechnicalExercise.Core.CoinChange
{
    /// <summary>
    /// A service for dealing with coin change.
    /// </summary>
    public interface ICoinChangeService
    {
        /// <summary>
        /// Gets the amount of coins for a given amount of pence.
        /// </summary>
        /// <param name="pence">The number of pence.</param>
        /// <returns>A <see cref="GenericResult{T}"/> holding the result and any validation errors.</returns>
        GenericResult<IDictionary<int, int>> GetCoinChange(string pence);
    }
}
