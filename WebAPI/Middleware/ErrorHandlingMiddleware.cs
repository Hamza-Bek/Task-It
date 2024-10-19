using Domain.Exceptions;
using FluentValidation;
using Shared.Responses;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middleware;

public class ErrorHandlingMiddleware
{
	private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

	public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// This method is responsible for handling all the exception types that could be thrown during the execution of a request
    /// To handle a different exception type, add a case for its type and the rest will be taken care of
    /// </summary>
    /// <param name="context"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        ApiErrorResponse? errorResponse = null;
        ValidationErrorResponse? validationErrorResponse = null;


        switch(ex)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                validationErrorResponse = new ValidationErrorResponse()
                {
                    ErrorMessage = "Invalid data",
                    ValidationErrors = validationException.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage),
                };
                _logger.LogError(validationException.Message);
                break;

            case AuthenticationFailedException authenticationFailedException:
                statusCode = HttpStatusCode.BadRequest;
                errorResponse = new ApiErrorResponse()
                {
                    ErrorMessage = authenticationFailedException.Message
                };
				_logger.LogError(authenticationFailedException.Message);
				break;

            case OperationFailedException operationFailedException:
				statusCode = HttpStatusCode.BadRequest;
                errorResponse = new ApiErrorResponse()
                {
                    ErrorMessage = operationFailedException.Message
                };
				_logger.LogError(operationFailedException.Message);
				break;

            case Exception e:
                statusCode = HttpStatusCode.InternalServerError;
                errorResponse = new ApiErrorResponse()
                {
                    ErrorMessage = "Something went wrong. Please try again"
                };
				_logger.LogError(e.Message);
				break;
		}

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var result = JsonSerializer.Serialize(validationErrorResponse ?? errorResponse);

        await context.Response.WriteAsync(result);
    }
}
