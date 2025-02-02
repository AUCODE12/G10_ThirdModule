using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services.Services;

namespace StudentManagementSystem.Server.Controllers;

[Route("api/admin")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public AdminController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }


}
