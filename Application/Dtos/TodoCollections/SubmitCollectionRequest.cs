namespace Application.Dtos.TodoCollections;

public class SubmitCollectionRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string CoverImageUrl { get; set; } = string.Empty;
}