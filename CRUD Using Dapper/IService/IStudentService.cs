using CRUD_Using_Dapper.Models;

namespace CRUD_Using_Dapper.IService
{
    public interface IStudentService
    {
        Student Save(Student student);

        List<Student> Gets();

        Student Get(int studentId);

        Student Delete(int studentId);
    }
}
