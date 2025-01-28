using StudentManagementSystem.DataAccess.Entities;

namespace StudentManagementSystem.Repositories.Services;

public class AdminRepository : IAdminRepository
{
    private string _data;
    private string _student;
    private string _teacher;

    public AdminRepository()
    {
         _data = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (!Directory.Exists(_data)) Directory.CreateDirectory(_data);
        _student = Path.Combine(_data, "students_data");
        if (!Directory.Exists(_student)) Directory.CreateDirectory(_student);
        _teacher = Path.Combine(_data, "teacher_data");
    }

    public void AddStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public Student GetStudentById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void AddTeacher(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public List<Teacher> GetAllTeachers()
    {
        throw new NotImplementedException();
    }

    public Teacher GetTeacherById(Guid id)
    {
        throw new NotImplementedException();
    }


    //
    private void SaveStudentData()
    {

    }
}
