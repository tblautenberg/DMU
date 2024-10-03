using System.ComponentModel.DataAnnotations;

namespace StudentAdminSys.Models {
    public class Student {
        [Required(ErrorMessage = "Student id was not read")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter the student's name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please choose an education")]
        public Education Education { get; set; }

        [Required(ErrorMessage = "Please choose an option")]
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Please enter the student's email")]
        [EmailAddress]
        public string? Email {  get; set; }
    }
    
    public enum Education {
        Byggekoordinator,
        Datamatiker,
        [Display(Name = "El-installatør")]
        Elinstallatør,
        Finansøkonom,
        Laborant,
        Markedsføringsøkonom,
        Multimediedesginer,
        Procesteknolog,
        Produktionsteknolog,
        [Display(Name = "Service- og Oplevelsesøkonom")]
        Serviceøkonom,
        [Display(Name = "VVS-installatør")]
        VVS
    }

    public enum Semesters {
        [Display (Name = "1st semester")]
        first,
        [Display(Name = "2nd semester")]
        second,
        [Display(Name = "3rd semester")]
        third,
        [Display(Name = "4th semester")]
        fourth,
        [Display(Name = "5th semester")]
        fifth
    }

    public static class EnumHelper {
        public static string GetEnumDisplayName(Enum value) {
            var attribute = value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().FirstOrDefault();

            return attribute?.GetName();
        }
    }
}