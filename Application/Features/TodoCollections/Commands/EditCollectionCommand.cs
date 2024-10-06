using Application.Dtos.TodoCollections;
using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Commands;

public record EditCollectionCommand(string CollectionId, SubmitCollectionRequest Model) : IRequest<TodoCollection>;