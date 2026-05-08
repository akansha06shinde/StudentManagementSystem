using Student_Management_System.Models;
using Student_Management_System.Repository;

namespace Student_Management_System.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;

        
        public StudentService(
            IStudentRepository repository,
            ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

       
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");

            return await _repository.GetAllAsync();
        }

        
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            _logger.LogInformation(
                "Fetching student with Id: {StudentId}", id);

            return await _repository.GetByIdAsync(id);
        }

       
        public async Task AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _logger.LogInformation(
                "Adding new student: {StudentName}", student.Name);

            await _repository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _logger.LogInformation(
                "Updating student with Id: {StudentId}", student.Id);

            await _repository.UpdateAsync(student);
        }

       
        public async Task DeleteStudentAsync(int id)
        {
            _logger.LogInformation(
                "Deleting student with Id: {StudentId}", id);

            await _repository.DeleteAsync(id);
        }
    }
}