namespace Shared.Responses;

public class ApiResponse
{
    public string? Message { get; set; }

    public bool IsSuccess { get; set; }
}

public class ApiResponse<T> : ApiResponse
{
    public T Data { get; private set; }

    public ApiResponse(T data)
    {
        Data = data;
    }
}