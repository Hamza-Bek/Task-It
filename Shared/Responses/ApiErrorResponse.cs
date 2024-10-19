namespace Shared.Responses;

public class ApiErrorResponse
{
    public string? ErrorMessage { get; set; }

    public List<string>? Errors { get; set; }
}

public class ValidationErrorResponse : ApiErrorResponse
{
    public Dictionary<string, string> ValidationErrors { get; set; } = [];
}