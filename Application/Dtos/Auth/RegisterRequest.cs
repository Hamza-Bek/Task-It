using System.Text.Json.Serialization;

namespace Application.Dtos.Auth;

public class RegisterRequest
{
	[JsonPropertyName("email")]
	public string Email { get; set; } = string.Empty;

	[JsonPropertyName("password")]
	public string Password { get; set; } = string.Empty;
}
