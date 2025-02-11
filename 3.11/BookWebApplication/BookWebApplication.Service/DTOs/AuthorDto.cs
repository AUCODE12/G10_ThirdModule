using BookWebApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookWebApplication.Service.DTOs;

public class AuthorDto
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Book>? Books { get; set; } // = new();
}
