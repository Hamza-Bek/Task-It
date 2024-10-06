namespace Shared.Responses;

public class ApiErrorResponse
{
    public string? ErrorMessage { get; set; }

    public List<string>? Errors { get; set; }
}