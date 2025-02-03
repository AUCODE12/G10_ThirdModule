using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services.DTOs;
using StudentManagementSystem.Services.Services;

namespace StudentManagementSystem.Server.Controllers;

[Route("api/admin")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }


    [HttpPost("addTeacher")]
    public async Task<Guid> AddTeacher(TeacherDto teacherDto)
    {
        var teacher = await _adminService.AddTeacherAsync(teacherDto);
        return teacher;
    }

    [HttpGet("getAllTeacher")]
    public async Task<List<TeacherDtoBase>> GetAllTeachers()
    {
        var teachers = await _adminService.GetAllTeachersAsync();
        return teachers;
    }

    [HttpGet("getTeacherById/{id}")]
    public async Task<TeacherDtoBase> GetTeacherById(Guid id)
    {
        var teacher = await _adminService.GetTeacherByIdAsync(id);
        return teacher;
    }
}
