using Application.Common;
using Application.Features.Todos.Queries;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Queries
{
    public class GetTodosHandler : IRequestHandler<GetTodosQuery, List<Todo>>
    {
        private readonly ITodosRepository _data;
        public GetTodosHandler(ITodosRepository data)
        {
            _data = data;
        }

        public async Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todosPageList = await _data.GetTodosAsync(request.PageRequest, request.CollectionId);           
            return todosPageList.Items.ToList();
        }
    }
}
