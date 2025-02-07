namespace BookWebApplication.Service.DTOs;

public class UserDto : UserGetDto
{
    public string Password { get; set; } = string.Empty;
}
