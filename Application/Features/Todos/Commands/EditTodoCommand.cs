using Amazon.Runtime.Internal;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands
{
    public record EditTodoCommand(string TodoId , Todo Todo) : IRequest<Todo>;
    
}
