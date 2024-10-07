using Application.Common;
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
        Task CreateTodoAsync(string collectionId ,Todo model);
        Task EditTodoAsync(string todoId, Todo model);
        Task DeleteTodoAsync(string todoId);
        Task<PageList<Todo>> GetTodosAsync(PageRequest pageRequest , string collectionId); // Get user's todos       
    }
}
