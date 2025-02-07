using BookWebApplication.DataAccess;
using BookWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Repository.Service;

public class CommentRepository : ICommentRepository
{
    private readonly MainContext _mainContext;

    public CommentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<int> AddCommentAsync(Comment comment)
    {
        await _mainContext.AddAsync(comment);
        await _mainContext.SaveChangesAsync();
        return comment.Id;
    }

    public async Task DeleteCommentAsync(int id)
    {
        var comment = await GetCommentByIdAsync(id);
        _mainContext.Comments.Remove(comment);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _mainContext.Comments.ToListAsync();
    }

    public async Task<Comment> GetCommentByIdAsync(int id)
    {
        var comment = await _mainContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (comment is null) throw new Exception("Not Found");
        return comment;
    }

    public async Task UpdateCommentAsync(Comment comment)
    {
        _mainContext.Comments.Update(comment);
        await _mainContext.SaveChangesAsync();
    }
}
