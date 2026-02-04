using System.Net;
using Todo.Application.Contracts.Errors;
using Todo.Application.Contracts.Exceptions;

namespace Todo.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) 
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            var statusCode = (int)HttpStatusCode.BadRequest;
            
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            var apiError = new ApiError(statusCode, ex.Message, ex.Errors);
            await response.WriteAsJsonAsync(apiError);
        }
        catch (AbstractHttpException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            context.Response.ContentType = "application/json";
            var apiError = new ApiError(ex.StatusCode, ex.GetApiError().Message, ex.GetApiError().Details);
            await context.Response.WriteAsJsonAsync(apiError);
        }
        catch (Exception ex)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var response = context.Response;

            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            var apiError = new ApiError(statusCode, ex.Message, ex.StackTrace);
            await response.WriteAsJsonAsync(apiError);
        }
    }
}
