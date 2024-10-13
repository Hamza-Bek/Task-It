using Application.Dtos.Auth;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Auth.Commands;

public class Register
{
	public class Command : IRequest<LoginResponse>
	{
        public RegisterRequest Model { get; set; }

        public Command(RegisterRequest model)
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
			var response = await _authService.RegisterAsync(request.Model, cancellationToken);
			return response;
		}
	}
}
