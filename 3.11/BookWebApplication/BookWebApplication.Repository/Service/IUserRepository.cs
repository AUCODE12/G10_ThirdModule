using BookWebApplication.DataAccess.Entities;

namespace BookWebApplication.Repository.Service;

public interface IUserRepository
{
    Task<int> AddUserAsync(User user); //c
    Task<List<User>> GetAllUsersAsync(); //r
    Task<User> GetUserByIdAsync(int id); //rid
    Task UpdateUserAsync(User updatedUser); //u
    Task DeleteUserAsync(int id); //d
}