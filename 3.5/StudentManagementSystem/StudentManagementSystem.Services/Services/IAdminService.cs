using StudentManagementSystem.DataAccess.Entities;
using StudentManagementSystem.Services.DTOs;

namespace StudentManagementSystem.Services.Services;

public interface IAdminService
{
    Task<Guid> AddTeacherAsync(TeacherDto teacherDto);

    Task<List<TeacherDtoBase>> GetAllTeachersAsync();

    Task<TeacherDtoBase> GetTeacherByIdAsync(Guid id);
}