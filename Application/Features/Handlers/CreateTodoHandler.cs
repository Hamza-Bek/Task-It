using Application.Features.Commands;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Handlers
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private readonly ITodosRepository _data;

        public CreateTodoHandler(ITodosRepository data)
        {
            _data = data;
        }
        public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            await _data.CreateTodoAsync(request.Todo);
            return request.Todo;
        }
    }
}
