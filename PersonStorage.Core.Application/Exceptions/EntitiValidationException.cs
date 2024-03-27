using System.Net;

namespace PersonStorage.Core.Application.Exceptions
{
    public class EntitiValidationException : ValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public EntitiValidationException(string message) : base(message) { }
    }
}
