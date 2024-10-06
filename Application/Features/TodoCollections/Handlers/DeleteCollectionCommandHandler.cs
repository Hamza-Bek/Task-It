using Application.Features.TodoCollections.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.TodoCollections.Handlers;

public class DeleteCollectionCommandHandler : IRequestHandler<DeleteCollectionCommand, bool>
{
    private readonly ITodoCollectionsRepository _collectionsRepository;

    public DeleteCollectionCommandHandler(ITodoCollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<bool> Handle(DeleteCollectionCommand request, CancellationToken cancellationToken)
    {
        return await _collectionsRepository.DeleteCollectionAsync(request.CollectionId, cancellationToken);
    }
}