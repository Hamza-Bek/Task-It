using Application.Features.Todos.Commands;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Todo;

namespace Application.Features.Todos.Handlers
{
    public class EditTodoHandler : IRequestHandler<EditTodoCommand, Todo>
    {
        private readonly ITodosRepository _data;
        public EditTodoHandler(ITodosRepository data)
        {
            _data = data;
        }

        public async Task<Todo> Handle(EditTodoCommand request, CancellationToken cancellationToken)
        {
            var updatedTodo = await _data.EditTodoAsync(request.TodoId, request.Todo);
            return updatedTodo;
        }
    }
}
