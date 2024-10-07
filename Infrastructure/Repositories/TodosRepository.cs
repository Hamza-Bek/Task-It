using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using MongoDB.Driver;
using Application.Common;
using MongoDB.Bson;

namespace Infrastructure.Repositories
{
    public class TodosRepository : ITodosRepository
    {
        private const string CollectionName = "todos-collection";
        private readonly IMongoCollection<Todo> _todosCollection;

        public TodosRepository(MongoDbContext dbContext)
        {
            _todosCollection = dbContext.GetCollection<Todo>(CollectionName);
        }

        public async Task CreateTodoAsync(string collectionId , Todo model)
        {
            if (model is null)             
                throw new ArgumentNullException(nameof(model), "Can not insert null values.");
            

            model.TodoCollectionId = collectionId;
            await _todosCollection.InsertOneAsync(model);
        }

        public async Task DeleteTodoAsync(string todoId)
        {
          if(string.IsNullOrEmpty(todoId))            
                throw new ArgumentNullException(nameof(todoId), "Todo ID cannot be null");
            

            var filter = Builders<Todo>.Filter.Eq(t => t.Id, todoId);

            await _todosCollection.DeleteOneAsync(filter);

        }   

        public async Task EditTodoAsync(string id, Todo model)
        {
            var filter = Builders<Todo>.Filter.Eq(t => t.Id, id);

            var result = await _todosCollection.ReplaceOneAsync(filter, model);

            if (result.MatchedCount == 0)
            {
                throw new KeyNotFoundException($"Todo with ID {id} was not found.");
            }
        }    

        public async Task<PageList<Todo>> GetTodosAsync(PageRequest pageRequest, string collectionId)
        {
           
            var filter = Builders<Todo>.Filter.Eq(f => f.TodoCollectionId, collectionId);
      
            var skip = (pageRequest.PageNumber - 1) * pageRequest.PageSize;

            if (pageRequest.SearchQuery is not null)
            {
                var searchFilter = Builders<Todo>.Filter.Regex(t => t.Title, new BsonRegularExpression(pageRequest.SearchQuery, "i"));
                filter = Builders<Todo>.Filter.And(filter, searchFilter);
            }

            var totalCount = (int)await _todosCollection.CountDocumentsAsync(filter);
          
            var todos = await _todosCollection
                .Find(filter)
                .Skip(skip)
                .Limit(pageRequest.PageSize)
                .ToListAsync();
          
            return new PageList<Todo>(todos, totalCount, pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
