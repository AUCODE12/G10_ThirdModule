using BookWebApplication.DataAccess;
using BookWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Repository.Service;

public class UserRepository : IUserRepository
{
    private readonly MainContext _mainContext;

    public UserRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<int> AddUserAsync(User user)
    {
        await _mainContext.Users.AddAsync(user);
        await _mainContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        _mainContext.Users.Remove(user);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _mainContext.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _mainContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null) throw new Exception("Not Found");
        return user;
    }

    public async Task UpdateUserAsync(User updatedUser)
    {
        _mainContext.Users.Update(updatedUser);
        await _mainContext.SaveChangesAsync();
    }
}
