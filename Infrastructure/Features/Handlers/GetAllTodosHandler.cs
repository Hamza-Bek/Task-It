using Application.Interfaces;
using Domain.Models;
using Infrastructure.Features.Queries;
using MediatR;
using System;

namespace Infrastructure.Features.Handlers
{
    public class GetAllTodosHandler : IRequestHandler<GetAllTodosQuery, List<Todo>>
    {
        private readonly ITodosRepository _data;
        public GetAllTodosHandler(ITodosRepository data)
        {
            _data = data;
        }

        public Task<List<Todo>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetAllTodosAsync());
        }
    }
}
