using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Dtos.Todo;

public class SubmitTodoRequest
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    public string OwnerId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public bool IsDone { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
}