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
        Task EditTodoAsync(Todo model);
        Task DeleteTodoAsync(Todo model);
                
        List<Todo> GetAllTodosAsync(); // Get user's todos
    }
}
