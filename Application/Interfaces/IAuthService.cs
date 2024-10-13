using Application.Dtos.Auth;

namespace Application.Interfaces;
public interface IAuthService
{
	Task<LoginResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);

	Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);

	Task<LoginResponse> RefreshAsync(RefreshRequest refreshToken, CancellationToken cancellationToken = default);
}
