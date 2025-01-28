using StudentManagementSystem.DataAccess.Entities;

namespace StudentManagementSystem.Repositories.Services;

public interface IAdminRepository
{
    void AddStudent(Student student);

    List<Student> GetAllStudents();

    Student GetStudentById(Guid id);

    void AddTeacher(Teacher teacher);

    List<Teacher> GetAllTeachers();

    Teacher GetTeacherById(Guid id);

    //void ChangeDetails();
}