using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TodosRepository : ITodosRepository
    {

        private List<Todo> todo = new();

        public TodosRepository()
        {
            todo.Add(new Todo { 
                Id = "1" ,
                Title ="Task #1" ,
                CreatedAt = DateTime.Now ,
                IsDone = false ,
                Priority = Priority.High ,
                OwnerId = "1" ,
                DueDate = DateTime.Now ,
                TodoCollectionId = "1"
            });            
        }

        public Task CreateTodoAsync(Todo model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTodoAsync(Todo model)
        {
            throw new NotImplementedException();
        }

        public Task EditTodoAsync(Todo model)
        {
            throw new NotImplementedException();
        }
      
        public List<Todo> GetAllTodosAsync()
        {
            return todo;
        }
    }
}
