using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public record CreateTodoCommand(string CollectionId, Todo Todo) : IRequest<Todo>;

}
