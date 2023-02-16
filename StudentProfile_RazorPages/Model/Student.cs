using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProfile_RazorPages.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }
      
        public int Age { get; set; }

        [Range(100, 500, ErrorMessage ="Level should either be 100, 200, 300, 400, 500")]
        [Required]
        public int Level { get; set; }

        [Required]
        [Display(Name = "Course")]
        public string course_of_study { get; set; }
        

    }
}
