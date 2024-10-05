using Domain.Models;

namespace Application.Interfaces;

public interface ITodoCollectionsRepostiory
{
    Task<TodoCollection> CreateCollectionAsync(TodoCollection collection);

    Task<TodoCollection> EditCollectionAsync(string id, TodoCollection collection);

    Task<bool> DeleteCollectionAsync(string id);

    Task<IEnumerable<TodoCollection>> GetCollectionsAsync();
}
