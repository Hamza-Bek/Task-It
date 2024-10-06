using Application.Features.TodoCollections.Commands;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Handlers;

public class EditCollectionCommandHandler : IRequestHandler<EditCollectionCommand, TodoCollection>
{
    private readonly ITodoCollectionsRepository _collectionsRepository;

    public EditCollectionCommandHandler(ITodoCollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<TodoCollection> Handle(EditCollectionCommand request, CancellationToken cancellationToken)
    {
        var updatedTodo = new TodoCollection()
        {
            Name = request.Collection.Name,
            Color = request.Collection.Color,
            Description = request.Collection.Description,
            CoverImageUrl = request.Collection.CoverImageUrl
        };

        return await _collectionsRepository.EditCollectionAsync(request.CollectionId, updatedTodo, cancellationToken);
    }
}