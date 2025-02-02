using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DataAccess;
using StudentManagementSystem.DataAccess.Entities;

namespace StudentManagementSystem.Repositories.Services;

public class TeacherRepository : ITeacherRepository
{
    private readonly MainContext _mainContext;

    public TeacherRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Guid> AddStudentAsync(Student student)
    {
        await _mainContext.AddAsync(student);
        await _mainContext.SaveChangesAsync();
        return student.Id;
    }

    public Task<List<Student>> GetAllStudentsAsync()
    {
        var students = _mainContext.Student.ToListAsync();
        return students;
    }

    public async Task<Student> GetStudentByIdAsync(Guid id)
    {
        var teacher = await _mainContext.Student.FirstOrDefaultAsync(x => x.Id == id);
        if (teacher is null) throw new Exception();
        return teacher;
    }
}
