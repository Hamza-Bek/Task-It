using Domain.Models;
using MediatR;


namespace Infrastructure.Features.Queries
{
    public record GetAllTodosQuery () : IRequest<List<Todo>>;
    
    
}
