using Student_Management_System.Models;

namespace Student_Management_System.Repository
{
    public interface IStudentRepository
    {
      
        Task<IEnumerable<Student>> GetAllAsync();

     
        Task<Student?> GetByIdAsync(int id);

       
        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

       
        Task DeleteAsync(int id);
    }
}