using System.Text.Json.Serialization;

namespace Application.Dtos.Auth;
public class LoginResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }
}
