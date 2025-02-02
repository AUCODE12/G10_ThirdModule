namespace StudentManagementSystem.Services.DTOs;

public class StudentDtoBase
{
    public Guid? Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Group { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}
