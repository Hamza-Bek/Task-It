﻿using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Todos.Commands
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private readonly ITodosRepository _data;

        public CreateTodoHandler(ITodosRepository data)
        {
            _data = data;
        }
        public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _data.CreateTodoAsync(request.CollectionId, request.Todo);
            return todo;
        }
    }
}
