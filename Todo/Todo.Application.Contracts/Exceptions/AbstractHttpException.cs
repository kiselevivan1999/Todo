using System.Net;
using Todo.Application.Contracts.Errors;

namespace Todo.Application.Contracts.Exceptions;

public class AbstractHttpException : Exception
{
    private readonly ApiError _apiError;
    public int StatusCode => _apiError.StatusCode;

    protected AbstractHttpException(HttpStatusCode httpCode, string title, object? details = default)
    {
        _apiError = new ApiError((int)httpCode, title, details);
    }

    public ApiError GetApiError()
    => _apiError;
}
