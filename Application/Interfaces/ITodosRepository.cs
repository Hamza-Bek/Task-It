using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITodosRepository
    {
        Task CreateTodoAsync(Todo model);
        Task EditTodoAsync(string id, Todo model);
        Task DeleteTodoAsync(string id);

        List<Todo> GetTodosAsync(string collectionId); // Get user's todos
    }
}
