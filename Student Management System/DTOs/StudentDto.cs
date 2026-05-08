using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.DTOs
{
    public class StudentDto
    {
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

       
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

       
        [Range(1, 50, ErrorMessage = "Age must be between 1 and 50")]
        public int Age { get; set; }

        // Student Course
        [Required(ErrorMessage = "Course is required")]
        [StringLength(100, ErrorMessage = "Course cannot exceed 100 characters")]
        public string Course { get; set; } = string.Empty;
    }
}