using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Commands;

public record EditCollectionCommand(string CollectionId, TodoCollection Collection) : IRequest<TodoCollection>;