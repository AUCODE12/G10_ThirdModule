using BookWebApplication.DataAccess.Entities;
using System.Text.Json.Serialization;

namespace BookWebApplication.Service.DTOs;

public class UserGetDto
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Comment>? Comments { get; set; } //= new();

}
