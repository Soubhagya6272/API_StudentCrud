using API_StudentCrud.Model;
namespace API_StudentCrud.Interface
{
    public interface IRepository
    {
        int SaveStudent(Student student);

        int UpdateStudent(Student student);
    }
}
