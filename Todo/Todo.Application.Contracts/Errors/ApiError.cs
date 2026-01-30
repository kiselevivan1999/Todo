namespace Todo.Application.Contracts.Errors;

public class ApiError
{
    /// <summary>
    /// Http код ошибки
    /// </summary>
    public int StatusCode { get; private set; }
    /// <summary>
    /// Заголовок ошибки
    /// </summary>
    public string Message { get; private set; }
    /// <summary>
    /// Доп информация
    /// </summary>
    public object? Details { get; private set; }

    public ApiError(int statusCode, string message, object? details = default)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
}
