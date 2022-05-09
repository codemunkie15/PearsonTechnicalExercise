namespace PearsonTechnicalExercise.Core
{
    /// <summary>
    /// Represents a result with a possible value, any errors and a success flag.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericResult<T>
    {
        /// <summary>
        /// The collection of errors.
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// The final result.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Whether the result was successful or not.
        /// </summary>
        public bool IsSuccessful => Errors == null || !Errors.Any();

        /// <summary>
        /// Creates a failed <see cref="GenericResult{T}"/> with the specified <paramref name="errorMessage"/>.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The created <see cref="GenericResult{T}"/>.</returns>
        public static GenericResult<T> Fail(string errorMessage) => new() { Errors = new[] { errorMessage }};

        /// <summary>
        /// Creates a successful <see cref="GenericResult{T}"/> with the specified <paramref name="result"/>.
        /// </summary>
        /// <param name="result">The returned value.</param>
        /// <returns>The created <see cref="GenericResult{T}"/>.</returns>
        public static GenericResult<T> Success(T result) => new() { Value = result };
    }
}