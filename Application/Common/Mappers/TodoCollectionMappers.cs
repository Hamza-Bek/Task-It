using Application.Dtos.TodoCollections;
using Domain.Models;

namespace Application.Common.Mappers;

public static class TodoCollectionMappers
{
    public static TodoCollectionDto ToDto(this TodoCollection collection)
    {
        return new()
        {
            Id = collection.Id!,
            Name = collection.Name,
            Description = collection.Description,
            Color = collection.Color,
            CoverImageUrl = collection.CoverImageUrl
        };
    }
}