using Amazon.Runtime.Internal;
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
    public record EditTodoCommand(string TodoId , SubmitTodoRequest Todo) : IRequest<Todo>;
    
}
