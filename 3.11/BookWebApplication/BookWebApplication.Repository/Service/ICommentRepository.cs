using BookWebApplication.DataAccess.Entities;

namespace BookWebApplication.Repository.Service;

public interface ICommentRepository
{
    Task<int> AddCommentAsync(Comment comment); //c
    Task<List<Comment>> GetAllCommentsAsync(); //r
    Task<Comment> GetCommentByIdAsync(int id); //rid
    Task UpdateCommentAsync(Comment comment); //u
    Task DeleteCommentAsync(int id); //d
}