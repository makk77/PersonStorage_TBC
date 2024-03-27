using System.Net;

namespace PersonStorage.Core.Application.Exceptions
{
    public class AlreadyExistsException : ValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public AlreadyExistsException(string message) : base(message) { }
    }
}
