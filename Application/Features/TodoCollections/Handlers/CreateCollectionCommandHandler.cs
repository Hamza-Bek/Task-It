using Application.Common;
using Application.Features.TodoCollections.Commands;
using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Features.TodoCollections.Handlers;

public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, TodoCollection>
{
    private readonly ITodoCollectionsRepository _collectionsRepository;
    private readonly UserIdentity _userIdentity;

    public CreateCollectionCommandHandler(ITodoCollectionsRepository collectionsRepository, UserIdentity userIdentity)
    {
        _collectionsRepository = collectionsRepository;
        _userIdentity = userIdentity;
    }

    public async Task<TodoCollection> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
    {
        var collection = new TodoCollection()
        {
            Name = request.Model.Name,
            Description = request.Model.Description,
            Color = request.Model.Color,
            CoverImageUrl = request.Model.CoverImageUrl
        };
        
        return await _collectionsRepository.CreateCollectionAsync(collection, cancellationToken);
    }
}