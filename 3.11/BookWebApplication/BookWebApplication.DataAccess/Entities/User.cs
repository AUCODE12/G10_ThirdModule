using System.ComponentModel.DataAnnotations;

namespace BookWebApplication.DataAccess.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Comment>? Comments { get; set; } //= new();
}
