using Amazon.Runtime.Internal;
using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Queries;

public record GetCollectionsQuery : IRequest<IEnumerable<TodoCollection>>;
