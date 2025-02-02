using StudentManagementSystem.DataAccess.Entities;

namespace StudentManagementSystem.Repositories.Services;

public interface IAdminRepository
{
    Task<Guid> AddTeacherAsync(Teacher teacher);

    Task<List<Teacher>> GetAllTeachersAsync();

    Task<Teacher> GetTeacherByIdAsync(Guid id);

}