using System.Net;

namespace Todo.Application.Contracts.Exceptions;

public class NotFoundException : AbstractHttpException
{
    public NotFoundException(string title, string id) :
        base(HttpStatusCode.NotFound, title, $"id: {id}")
    { }
}
