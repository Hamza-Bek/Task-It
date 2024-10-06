namespace Application.Dtos.TodoCollections;

public class TodoCollectionDto
{
    public string Id { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Color { get; set; }

    public string? CoverImageUrl { get; set; }
    
}