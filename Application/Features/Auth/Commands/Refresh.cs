using Application.Dtos.Auth;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Auth.Commands;

public class Refresh
{
	public class Command : IRequest<LoginResponse>
	{
        public RefreshRequest Model { get; set; }

        public Command(RefreshRequest model)
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
			var response = await _authService.RefreshAsync(request.Model, cancellationToken);
			return response;
		}
	}
}
