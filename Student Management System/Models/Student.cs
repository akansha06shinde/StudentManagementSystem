using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Student
    {
       
        [Key]
        public int Id { get; set; }

       
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

       
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Course { get; set; } = string.Empty;

       
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}