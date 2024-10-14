using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using MongoDB.Driver;
using Application.Common;
using Application.Dtos.Todo;
using MongoDB.Bson;

namespace Infrastructure.Repositories
{
    public class TodosRepository : ITodosRepository
    {
        private const string CollectionName = "todos-collection";
        private readonly IMongoCollection<Todo> _todosCollection;
        private readonly UserIdentity _userIdentity;

        public TodosRepository(MongoDbContext dbContext)
        {
            _todosCollection = dbContext.GetCollection<Todo>(CollectionName);
        }

        public async Task<Todo> CreateTodoAsync(string collectionId, SubmitTodoRequest model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model), "Can not insert null values.");
            
            var todo = new Todo
            {
                Id = Guid.NewGuid().ToString(), 
                Title = model.Title,
                Content = model.Content,
                Priority = model.Priority,
                DueDate = model.DueDate,
                IsDone = model.IsDone,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
                TodoCollectionId = collectionId
            };
            
            await _todosCollection.InsertOneAsync(todo);
            
            return todo;
        }

        public async Task DeleteTodoAsync(string todoId)
        {
          if(string.IsNullOrEmpty(todoId))
                throw new ArgumentNullException(nameof(todoId), "Todo ID cannot be null");


            var filter = Builders<Todo>.Filter.Eq(t => t.Id, todoId);

            await _todosCollection.DeleteOneAsync(filter);

        }

        public async Task<Todo> GetTodoByIdAsync(string ownerId, string todoId)
        {

            var filter = Builders<Todo>.Filter.And
            (
                Builders<Todo>.Filter.Eq(t => t.Id, todoId),
                Builders<Todo>.Filter.Eq(i => i.OwnerId, ownerId)
            );

            var todo = _todosCollection.Find(filter).FirstOrDefaultAsync();

            return await todo;
        }

        public async Task<Todo> EditTodoAsync(string id, SubmitTodoRequest model)
        {

            var filter = Builders<Todo>.Filter.Eq(t => t.Id, id);

            var existingTodo = _todosCollection.Find(filter).FirstOrDefaultAsync();

            if (existingTodo is null)
            {
                throw new KeyNotFoundException($"Todo with ID {id} was not found.");
            }

            var update = Builders<Todo>.Update
                .Set(x => x.Title ,model.Title)
                .Set(x => x.Content, model.Content)
                .Set(x => x.Priority, model.Priority)
                .Set(x => x.DueDate, model.DueDate)
                .Set(x=> x.IsDone, model.IsDone)
                .Set(x=> x.LastUpdatedAt, DateTime.UtcNow);

            var updatedTodo = await _todosCollection.FindOneAndUpdateAsync(filter, update ,new FindOneAndUpdateOptions<Todo>
            {
                ReturnDocument = ReturnDocument.After
            });

            return updatedTodo;
        }

        public async Task<PageList<Todo>> GetTodosAsync(PageRequest pageRequest, string collectionId)
        {

            var filter = Builders<Todo>.Filter.And
                (
                Builders<Todo>.Filter.Eq(f => f.TodoCollectionId, collectionId),
                Builders<Todo>.Filter.Eq(i => i.OwnerId , _userIdentity.Id)
                );

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
