using BookWebApplication.Service.DTOs;
using BookWebApplication.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApplication.Server.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("add")]
    public async Task<int> AddCommentAsync(CommentDto comment)
    {
        return await _commentService.AddCommentAsync(comment);
    }

    [HttpGet("getAll")]
    public async Task<List<CommentDto>> GetAllCommentsAsync()
    {
        return await _commentService.GetAllCommentsAsync();
    }

    [HttpGet("getById/{id}")]
    public async Task<CommentDto> GetCommentByIdAsync(int id)
    {
        return await _commentService.GetCommentByIdAsync(id);
    }

    [HttpPut("update")]
    public async Task UpdateCommentAsync(CommentDto commentDto)
    {
        await _commentService.UpdateCommentAsync(commentDto);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeleteCommentAsync(int id)
    {
        await _commentService.DeleteCommentAsync(id);
    }
}
