using System.ComponentModel.DataAnnotations;
using StudentAdminSys.Models; // Correct namespace for the 'Student' class

namespace StudentAdminSys.Test
{
    public class UnitTest1
    {
        [Fact]
        public void StudentNameIsRequired()
        {
            // Arrange
            var student = new Student
            {
                Name = null,  // Name is required
                Education = 1,
                SemesterId = 1,
                Email = "test@example.com"
            };

            // Act
            var context = new ValidationContext(student);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(student, context, results, true);

            // Assert
            Assert.False(isValid);  // Name is missing, so the model should be invalid
        }
    }
}
