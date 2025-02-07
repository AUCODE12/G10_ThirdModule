namespace BookWebApplication.Service.DTOs;

public class CommentDto
{
    public int? Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int BookId { get; set; }
    public int UserId { get; set; }
}
