using Domain.Models;
using Infrastructure.Features.Queries;
using MediatR;

namespace Infrastructure.Features.Handlers
{
    public class GetTodosHandler : IRequestHandler<GetTodosQuery , Todo>
    {
        private readonly IMediator _mediator;
        public GetTodosHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Todo> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTodosQuery());

            var output = result.FirstOrDefault(i => i.OwnerId == request.ownerId);

            return output!;
        }
    }
}
