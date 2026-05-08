
using Student_Management_System.Data;
using Student_Management_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Student_Management_System.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All Students
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Get Student By Id
        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Add Student
        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        // Update Student
        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        // Delete Student
        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}