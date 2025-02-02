using StudentManagementSystem.DataAccess.Entities;
using StudentManagementSystem.Repositories.Services;
using StudentManagementSystem.Services.DTOs;

namespace StudentManagementSystem.Services.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Guid> AddStudentAsync(StudentDto studentDto)
    {
        var student = await _teacherRepository.AddStudentAsync(ConvertToStudentEntity(studentDto));
        return student;
    }

    public async Task<List<StudentDtoBase>> GetAllStudentsAsync()
    {
        var students = await _teacherRepository.GetAllStudentsAsync();
        return students.Select(student => ConvertToDto(student)).ToList();
    }

    public async Task<StudentDtoBase> GetStudentByIdAsync(Guid id)
    {
        var student = await _teacherRepository.GetStudentByIdAsync(id);
        return ConvertToDto(student);
    }

    private Student ConvertToStudentEntity(StudentDto studentDto)
    {
        return new Student
        {
            Email = studentDto.Email,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Group = studentDto.Group,
            Id = studentDto.Id ?? Guid.NewGuid(),
            Password = studentDto.Password,
            PhoneNumber = studentDto.PhoneNumber,
        };
    }
    /* private Student ConvertToStudentEntity(StudentDtoBase studentDtoBase)
    {
        return new Student
        {
            PhoneNumber = studentDtoBase.PhoneNumber,
            LastName = studentDtoBase.LastName,
            Id = studentDtoBase.Id,
            Group = studentDtoBase.Group,
            FirstName = studentDtoBase.FirstName,
            Email = studentDtoBase.Email,
        };
    } */
    private StudentDtoBase ConvertToDto(Student student)
    {
        return new StudentDtoBase
        {
            Email = student.Email,
            FirstName = student.FirstName,
            Group = student.Group,
            Id = student.Id,
            LastName = student.LastName,
            PhoneNumber = student.PhoneNumber,
        };
    }
}
