using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public interface IUserService
{
    Task<int> AddUserAsync(UserDto userDto); //c
    Task<List<UserGetDto>> GetAllUsersAsync(); //r
    Task<UserGetDto> GetUserByIdAsync(int id); //rid
    Task UpdateUserAsync(UserDto updatedUserDto); //u
    Task DeleteUserAsync(int id); //d
}