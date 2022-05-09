namespace PearsonTechnicalExercise.Core.CoinChange
{
    internal class CoinChangeService : ICoinChangeService
    {
        private readonly IEnumerable<int> coins = new[] { 1, 2, 5, 10, 20, 50, 100 };

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

            foreach (var coin in coins.OrderByDescending(c => c))
            {
                while (pence >= coin)
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
