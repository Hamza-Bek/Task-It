using Application.Features.Todos.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Todos.Handlers;

public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand , bool>
{
    private readonly ITodosRepository _data;

    public DeleteTodoHandler(ITodosRepository data)
    {
        _data = data;
    }
    public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        await _data.DeleteTodoAsync(request.TodoId);

        return true;
    }
}