using Domain.Models;
using MediatR;


namespace Infrastructure.Features.Queries
{
    public record GetTodosQuery(string ownerId) : IRequest<Todo>;
}
