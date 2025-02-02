using StudentManagementSystem.DataAccess.Entities;

namespace StudentManagementSystem.Repositories.Services;

public interface ITeacherRepository
{
    Task<Guid> AddStudentAsync(Student student);

    Task<List<Student>> GetAllStudentsAsync();

    Task<Student> GetStudentByIdAsync(Guid id);
}