using Application.Dtos.Auth;
using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Auth.Commands;
public class Login
{
	public class Command : IRequest<LoginResponse>
	{
        public LoginRequest Model { get; set; }

        public Command(LoginRequest model)
        {
            Model = model;
        }
    }

	public class Handler : IRequestHandler<Command, LoginResponse>
	{
		private readonly IAuthService _authService;

		public Handler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<LoginResponse> Handle(Command request, CancellationToken cancellationToken)
		{
			var response = await _authService.LoginAsync(request.Model, cancellationToken);
			return response;
		}
	}
}