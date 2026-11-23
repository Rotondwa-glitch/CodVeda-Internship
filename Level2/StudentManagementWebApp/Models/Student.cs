
using System.ComponentModel.DataAnnotations;

namespace StudentManagementWebApp.Models
{
    public class Student
    {
        // Unique student ID
        public int Id { get; set; }

        // Student's full name
        [Required(ErrorMessage = "Please enter the student's name.")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        // Student's email address
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        // Student's age
        [Range(16, 100, ErrorMessage = "Age must be between 16 and 100.")]
        public int Age { get; set; }

        // Student's course
        [Required(ErrorMessage = "Please enter the course.")]
        public string Course { get; set; } = string.Empty;
    }
}
