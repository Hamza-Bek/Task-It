using Application.Common;
using Application.Dtos.Auth;
using Application.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly ISender _sender;
	private readonly UserIdentity _identity;

	public AuthController(ISender sender, UserIdentity identity)
	{
		_sender = sender;
		_identity = identity;
	}

	[HttpPost("register")]
	public async Task<IActionResult> RegsiterUserAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken)
	{
		var command = new Register.Command(request);
		var response = await _sender.Send(command, cancellationToken);
		return Ok(new ApiResponse<LoginResponse>(response)
		{
			Message = "User registration succeeded",
			IsSuccess = true
		});
	}

	[HttpPost("login")]
	public async Task<IActionResult> LoginUserAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
	{
		var command = new Login.Command(request);
		var response = await _sender.Send(command, cancellationToken);
		return Ok(new ApiResponse<LoginResponse>(response)
		{
			Message = "Login successded",
			IsSuccess = true
		});
	}

	[HttpPost("refresh")]
	public async Task<IActionResult> RefreshUserTokenAsync([FromBody] RefreshRequest request, CancellationToken cancellationToken)
	{
		var command = new Refresh.Command(request);
		var response = await _sender.Send(command, cancellationToken);
		return Ok(new ApiResponse<LoginResponse>(response)
		{
			Message = "Refresh successded",
			IsSuccess = true
		});
	}
}
