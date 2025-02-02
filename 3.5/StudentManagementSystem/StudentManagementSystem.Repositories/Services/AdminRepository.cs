using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DataAccess;
using StudentManagementSystem.DataAccess.Entities;

namespace StudentManagementSystem.Repositories.Services;

public class AdminRepository : IAdminRepository
{
    private readonly MainContext _mainContext;
    public AdminRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Guid> AddTeacherAsync(Teacher teacher)
    {
        await _mainContext.AddAsync(teacher);
        await _mainContext.SaveChangesAsync();
        return teacher.Id;
    }

    public async Task<List<Teacher>> GetAllTeachersAsync()
    {
        var teachers = await _mainContext.Teacher.ToListAsync();
        return teachers;
    }

    public async Task<Teacher> GetTeacherByIdAsync(Guid id)
    {
        var teacher = await _mainContext.Teacher.FirstOrDefaultAsync(x => x.Id == id);
        if (teacher is null) throw new Exception();
        return teacher;
    }
}
