using System.ComponentModel.DataAnnotations;

namespace StudentAdmin.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string? Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your education")]
        public string? Education { get; set; }

        [Required(ErrorMessage = "Please enter your semester (1,2,3 etc..)")]
        [Range(1,4)]
        public int? Semester { get; set; }

    }
}
