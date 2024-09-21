﻿using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using MongoDB.Driver;

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

        public Task CreateTodoAsync(Todo model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTodoAsync(string toodId)
        {
            throw new NotImplementedException();
        }

        public Task EditTodoAsync(string todoId, Todo model)
        {
            throw new NotImplementedException();
        }

        public List<Todo> GetTodosAsync(string collectionId)
        {
            return Enumerable.Empty<Todo>().ToList();
        }
    }
}
