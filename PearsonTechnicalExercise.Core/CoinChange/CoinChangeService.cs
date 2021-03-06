namespace PearsonTechnicalExercise.Core.CoinChange
{
    /// <summary>
    /// A service for dealing with coin change.
    /// </summary>
    internal class CoinChangeService : ICoinChangeService
    {
        private readonly IEnumerable<int> coins = new[] { 1, 2, 5, 10, 20, 50, 100 };

        /// <inheritdoc/>
        public GenericResult<IDictionary<int, int>> GetCoinChange(string penceString)
        {
            if (!int.TryParse(penceString, out var pence))
            {
                return GenericResult<IDictionary<int, int>>.Fail("Please enter a number.");
            }

            if (pence < 0)
            {
                return GenericResult<IDictionary<int, int>>.Fail("Please enter a positive pence amount.");
            }

            var changeCoins = new List<int>();

            foreach (var coin in coins.OrderByDescending(c => c)) // Check the highest coin first
            {
                while (pence >= coin) // Keep adding change until no more of the coin will fit
                {
                    changeCoins.Add(coin);
                    pence -= coin;
                }
            }

            var groupedCoins = changeCoins.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            return GenericResult<IDictionary<int, int>>.Success(groupedCoins);
        }
    }
}
