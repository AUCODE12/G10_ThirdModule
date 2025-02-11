using BookWebApplication.DataAccess.Entities;
using System.Text.Json.Serialization;

namespace BookWebApplication.Service.DTOs;

public class CommentDto
{
    public int? Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int BookId { get; set; }
    [JsonIgnore]
    public Book? Book { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}
