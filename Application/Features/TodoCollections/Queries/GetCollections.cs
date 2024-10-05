using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Queries;

public record GetCollections() : IRequest<IEnumerable<TodoCollection>>;