namespace WebAPI.Options;

public class AuthenticationOptions
{
    public string ValidIssuer { get; set; } = string.Empty;

    public string ValidAudience { get; set; } = string.Empty;

    public string JwtSecret { get; set; } = string.Empty;
}
