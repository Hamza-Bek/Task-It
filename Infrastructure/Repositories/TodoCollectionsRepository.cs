using Application.Common;
using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class TodoCollectionsRepository : ITodoCollectionsRepository
{
    private const string CollectionName = "todo-collections-collection";
    private readonly IMongoCollection<TodoCollection> _collection;
    private readonly UserIdentity _userIdentity;

    public TodoCollectionsRepository(MongoDbContext dbContext, UserIdentity userIdentity)
    {
        _collection = dbContext.GetCollection<TodoCollection>(CollectionName);
        _userIdentity = userIdentity;
    }

    public async Task<TodoCollection> CreateCollectionAsync(TodoCollection collection, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(collection, cancellationToken: cancellationToken);
        return collection;
    }

    public async Task<TodoCollection> EditCollectionAsync(string id, TodoCollection collection, CancellationToken cancellationToken = default)
    {
        var filter = Builders<TodoCollection>
            .Filter
            .Eq(x => x.Id, id);
        
        var update = Builders<TodoCollection>.Update
            .Set(x => x.Name, collection.Name)
            .Set(x => x.Description, collection.Description)
            .Set(x => x.CoverImageUrl, collection.CoverImageUrl)
            .Set(x => x.Color, collection.Color)
            .Set(x => x.LastUpdatedAt, DateTime.UtcNow);

        var result = await _collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

        if (result.ModifiedCount > 0)
        {
            // Fetch the updated document and return it
            return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
        else
        {
            // Return null or handle the case where no document was updated
            throw new OperationFailedException("Something went wrong. Please try again.");
        }
    }

    public async Task<bool> DeleteCollectionAsync(string id, CancellationToken cancellationToken = default)
    {
        var filter = Builders<TodoCollection>
            .Filter
            .Eq(x => x.Id, id);

        var result = await _collection.DeleteOneAsync(filter, cancellationToken);

        if (result.DeletedCount > 0)
        {
            return true;
        }
        else
        {
            throw new OperationFailedException("Something went wrong. Please try again.");
        }
    }

    public async Task<IEnumerable<TodoCollection>> GetCollectionsAsync(CancellationToken cancellationToken = default)
    {
        var filter = Builders<TodoCollection>
            .Filter
            .Eq(x => x.OwnerId, _userIdentity.Id);
        
        var collections = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);
        
        return collections;
    }
}