using StudentManagementSystem.Services.DTOs;

namespace StudentManagementSystem.Services.Services;

public interface ITeacherService
{
    Task<Guid> AddStudentAsync(StudentDto studentDto);

    Task<List<StudentDtoBase>> GetAllStudentsAsync();

    Task<StudentDtoBase> GetStudentByIdAsync(Guid id);
}