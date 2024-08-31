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

        public async Task CreateTodoAsync(Todo model)
        {
            model.Id = Guid.NewGuid().ToString();
            todo.Add(model);            
        }

        public Task DeleteTodoAsync(Todo model)
        {
            throw new NotImplementedException();
        }

        public Task EditTodoAsync(Todo model)
        {
            throw new NotImplementedException();
        }
      
        public List<Todo> GetTodosAsync(string ownerId)
        {            
            return todo.Where(i => i.OwnerId == ownerId).ToList();
        }
    }
}
