using Amazon.Runtime.Internal;
using Application.Common;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Queries
{
    public record GetTodosQuery(PageRequest PageRequest, string CollectionId) : IRequest<List<Todo>>;
}