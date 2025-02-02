using StudentManagementSystem.DataAccess.Entities;
using StudentManagementSystem.Repositories.Services;
using StudentManagementSystem.Services.DTOs;

namespace StudentManagementSystem.Services.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Guid> AddTeacherAsync(TeacherDto teacherDto)
    {
        var teacher = await _adminRepository.AddTeacherAsync(ConvertToStudentEntity(teacherDto));
        return teacher;
    }

    public async Task<List<TeacherDtoBase>> GetAllTeachersAsync()
    {
        var teachers = await _adminRepository.GetAllTeachersAsync();
        return teachers.Select(t => ConvertToDto(t)).ToList();
    }

    public async Task<TeacherDtoBase> GetTeacherByIdAsync(Guid id)
    {
        var teacher = await _adminRepository.GetTeacherByIdAsync(id);
        return ConvertToDto(teacher);
    }

    private Teacher ConvertToStudentEntity(TeacherDto teacherDto)
    {
        return new Teacher
        {
            Email = teacherDto.Email,
            FirstName = teacherDto.FirstName,
            LastName = teacherDto.LastName,
            Id = teacherDto.Id ?? Guid.NewGuid(),
            Password = teacherDto.Password,
            PhoneNumber = teacherDto.PhoneNumber,
            Subject = teacherDto.Subject,
        };
    }
    /*private Teacher ConvertToStudentEntity(TeacherDtoBase teacherDtoBase)
    {
        return new Teacher
        {
            Email = teacherDtoBase.Email,
            FirstName = teacherDtoBase.FirstName,
            LastName = teacherDtoBase.LastName,
            PhoneNumber = teacherDtoBase.PhoneNumber,
            Subject = teacherDtoBase.Subject,
            Id = teacherDtoBase.Id,
        };
    }*/
    private TeacherDtoBase ConvertToDto(Teacher teacher)
    {
        return new TeacherDtoBase
        {
            Subject = teacher.Subject,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            Id = teacher.Id,
            LastName = teacher.LastName,
            PhoneNumber = teacher.PhoneNumber
        };
    }
}
