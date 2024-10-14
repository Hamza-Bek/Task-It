using Application.Dtos.Auth;
using Application.Interfaces;
using Domain.Exceptions;
using System.Net.Http.Json;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
	private const string SupabaseClientName = "SupabaseClient";
	private readonly HttpClient _httpClient;

    public AuthService(IHttpClientFactory httpClientFactory)
    {
		_httpClient = httpClientFactory.CreateClient(SupabaseClientName);
    }

	public async Task<LoginResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
	{
		var response = await _httpClient.PostAsJsonAsync($"/auth/v1/signup", request, cancellationToken);

		if (!response.IsSuccessStatusCode)
		{
			var failedResponse = await response.Content.ReadFromJsonAsync<AuthFailedResponse>(cancellationToken);
			throw new AuthenticationFailedException(failedResponse!.Message);
		}

		var data = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);
		return data!;
	}

	public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
	{
		var response = await _httpClient.PostAsJsonAsync($"/auth/v1/token?grant_type=password", request, cancellationToken);

		if(!response.IsSuccessStatusCode)
		{
			var failedResponse = await response.Content.ReadFromJsonAsync<AuthFailedResponse>(cancellationToken);
			throw new AuthenticationFailedException(failedResponse!.Message);
		}

		var data = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);
		return data!;
	}

	public async Task<LoginResponse> RefreshAsync(RefreshRequest refreshToken, CancellationToken cancellationToken = default)
	{
		var response = await _httpClient.PostAsJsonAsync($"/auth/v1/token?grant_type=refresh_token", refreshToken, cancellationToken);

		if (!response.IsSuccessStatusCode)
		{
			var failedResponse = await response.Content.ReadFromJsonAsync<AuthFailedResponse>(cancellationToken);
			throw new AuthenticationFailedException(failedResponse!.Message);
		}

		var data = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);
		return data!;
	}
}
