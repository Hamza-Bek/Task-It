using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Todo;

namespace Application.Features.Todos.Commands
{
    public record CreateTodoCommand(string CollectionId, SubmitTodoRequest Todo) : IRequest<Todo>;

}
