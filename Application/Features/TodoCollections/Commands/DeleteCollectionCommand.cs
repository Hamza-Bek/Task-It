using MediatR;

namespace Application.Features.TodoCollections.Commands;

public record DeleteCollectionCommand(string CollectionId) : IRequest<bool>;