using Application.Dtos.TodoCollections;
using Domain.Models;
using MediatR;

namespace Application.Features.TodoCollections.Commands;

public record CreateCollectionCommand(SubmitCollectionRequest Model) : IRequest<TodoCollection>;