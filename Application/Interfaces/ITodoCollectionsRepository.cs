using Domain.Models;

namespace Application.Interfaces;

public interface ITodoCollectionsRepository
{
    Task<TodoCollection> CreateCollectionAsync(TodoCollection collection, CancellationToken cancellationToken = default);

    Task<TodoCollection> EditCollectionAsync(string id, TodoCollection collection, CancellationToken cancellationToken = default);

    Task<bool> DeleteCollectionAsync(string id, CancellationToken cancellationToken = default);

    Task<IEnumerable<TodoCollection>> GetCollectionsAsync(CancellationToken cancellationToken = default);
}
