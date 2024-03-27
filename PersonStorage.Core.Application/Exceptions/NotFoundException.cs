using System.Net;

namespace PersonStorage.Core.Application.Exceptions
{
    public class NotFoundException : ValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public NotFoundException(string message) : base(message) { }
    }
}
