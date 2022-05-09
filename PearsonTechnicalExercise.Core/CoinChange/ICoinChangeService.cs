namespace PearsonTechnicalExercise.Core.CoinChange
{
    public interface ICoinChangeService
    {
        GenericResult<IDictionary<int, int>> GetCoinChange(string pence);
    }
}
