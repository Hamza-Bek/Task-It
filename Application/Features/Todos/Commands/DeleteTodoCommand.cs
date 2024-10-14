using MediatR;

namespace Application.Features.Todos.Commands;

public record DeleteTodoCommand(string TodoId) : IRequest<bool>;