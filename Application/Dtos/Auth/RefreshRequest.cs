using System.Text.Json.Serialization;

namespace Application.Dtos.Auth;
public class RefreshRequest
{
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;
}
