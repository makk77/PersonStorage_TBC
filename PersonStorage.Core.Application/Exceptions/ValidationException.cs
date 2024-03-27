namespace PersonStorage.Core.Application.Exceptions
{
    public abstract class ValidationException : Exception
    {
        public abstract int StatusCode { get; }

        public ValidationException(string message) : base(message) { }
    }
}
