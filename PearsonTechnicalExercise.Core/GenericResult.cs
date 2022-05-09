namespace PearsonTechnicalExercise.Core
{
    public class GenericResult<T>
    {
        public IEnumerable<string> Errors { get; set; }

        public T Value { get; set; }

        public bool IsSuccessful => Errors == null || !Errors.Any();

        public static GenericResult<T> Fail(string errorMessage) => new() { Errors = new[] { errorMessage }};

        public static GenericResult<T> Success(T result) => new() { Value = result };
    }
}
