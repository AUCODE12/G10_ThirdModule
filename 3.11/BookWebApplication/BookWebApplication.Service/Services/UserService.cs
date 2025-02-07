using BookWebApplication.DataAccess.Entities;
using BookWebApplication.Repository.Service;
using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> AddUserAsync(UserDto userDto)
    {
        return await _userRepository.AddUserAsync(ConvertToUserEntity(userDto));
    }

    public async Task<List<UserGetDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(u => ConvertToBookDto(u)).ToList();
    }

    public async Task<UserGetDto> GetUserByIdAsync(int id)
    {
        return ConvertToBookDto(await _userRepository.GetUserByIdAsync(id));
    }

    public async Task UpdateUserAsync(UserDto updatedUserDto)
    {
        await _userRepository.UpdateUserAsync(ConvertToUserEntity(updatedUserDto));
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }

    private User ConvertToUserEntity(UserDto userDto)
    {
        return new User
        {
            Email = userDto.Email,
            Name = userDto.Name,
            Password = userDto.Password,
            Id = userDto.Id ?? 0
        };
    }

    private UserGetDto ConvertToBookDto(User user)
    {
        return new UserGetDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
}
