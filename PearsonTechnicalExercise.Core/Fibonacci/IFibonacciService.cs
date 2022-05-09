namespace PearsonTechnicalExercise.Core.Fibonacci
{
    public interface IFibonacciService
    {
        GenericResult<int> GetFibonacciSum(string n);
    }
}
