using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Commands;

public record CreateCollectionCommand(string OwnerId, string Name) : IRequest<TodoCollection>;