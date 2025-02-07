﻿namespace BookWebApplication.Service.DTOs;

public class BookDto
{
    public int? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}
