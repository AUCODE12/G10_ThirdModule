using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services.DTOs;
using StudentManagementSystem.Services.Services;

namespace StudentManagementSystem.Server.Controllers;

[Route("api/teacher")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpPost("addStudent")]
    public async Task<Guid> AddStudent(StudentDto studentDto)
    {
        var student = await _teacherService.AddStudentAsync(studentDto);
        return student;
    }

    [HttpGet("getAllStudent")]
    public async Task<List<StudentDtoBase>> GetAllStudents()
    {
        var students = await _teacherService.GetAllStudentsAsync();
        return students;
    }

    [HttpGet("getTeacherById/{id}")]    
    public async Task<StudentDtoBase> GetStudentById(Guid id)
    {
        var teacher = await _teacherService.GetStudentByIdAsync(id);
        return teacher;
    }
}
