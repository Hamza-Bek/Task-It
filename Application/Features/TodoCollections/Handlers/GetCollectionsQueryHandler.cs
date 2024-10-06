using Application.Features.TodoCollections.Queries;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Handlers;

public class GetCollectionsQueryHandler : IRequestHandler<GetCollectionsQuery, IEnumerable<TodoCollection>>
{
    private readonly ITodoCollectionsRepository _collectionsRepository;

    public GetCollectionsQueryHandler(ITodoCollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<IEnumerable<TodoCollection>> Handle(GetCollectionsQuery request, CancellationToken cancellationToken)
    {
        return await _collectionsRepository.GetCollectionsAsync(cancellationToken);
    }
}
