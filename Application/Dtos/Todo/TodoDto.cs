using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Dtos.Todo;

public class TodoDto
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public bool IsDone { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
}