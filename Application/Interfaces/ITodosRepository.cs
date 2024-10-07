using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Todo;

namespace Application.Interfaces
{
    public interface ITodosRepository
    {
        Task<Todo> CreateTodoAsync(string collectionId, SubmitTodoRequest model);
        Task<Todo> EditTodoAsync(string todoId, SubmitTodoRequest model);
        Task DeleteTodoAsync(string todoId);

        Task<Todo> GetTodoByIdAsync(string ownerId, string todoId);
        Task<PageList<Todo>> GetTodosAsync(PageRequest pageRequest , string collectionId); // Get user's todos
    }
}
