using BookWebApplication.DataAccess.Entities;
using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public interface ICommentService
{
    Task<int> AddCommentAsync(CommentDto commentDto); //c
    Task<List<CommentDto>> GetAllCommentsAsync(); //r
    Task<CommentDto> GetCommentByIdAsync(int id); //rid
    Task UpdateCommentAsync(CommentDto commentDto); //u
    Task DeleteCommentAsync(int id); //d
}