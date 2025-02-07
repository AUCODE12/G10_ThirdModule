using BookWebApplication.DataAccess.Entities;
using BookWebApplication.Repository.Service;
using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<int> AddCommentAsync(CommentDto commentDto)
    {
        return await _commentRepository.AddCommentAsync(ConvertToCommentEntity(commentDto));
    }

    public async Task DeleteCommentAsync(int id)
    {
        await _commentRepository.DeleteCommentAsync(id);
    }

    public async Task<List<CommentDto>> GetAllCommentsAsync()
    {
        var comments = await _commentRepository.GetAllCommentsAsync();
        return comments.Select(c => ConvertToCommentDto(c)).ToList();
    }

    public async Task<CommentDto> GetCommentByIdAsync(int id)
    {
        return ConvertToCommentDto(await _commentRepository.GetCommentByIdAsync(id));
    }

    public async Task UpdateCommentAsync(CommentDto commentDto)
    {
        await _commentRepository.UpdateCommentAsync(ConvertToCommentEntity(commentDto));
    }

    private Comment ConvertToCommentEntity(CommentDto commentDto)
    {
        return new Comment
        {
            UserId = commentDto.UserId,
            Id = commentDto.Id ?? 0,
            Content = commentDto.Content,
            BookId = commentDto.BookId,
        };
    }

    private CommentDto ConvertToCommentDto(Comment comment) 
    {
        return new CommentDto
        {
            BookId = comment.BookId,
            Content = comment.Content,
            Id = comment.Id,
            UserId = comment.UserId,
        };
    }
}
