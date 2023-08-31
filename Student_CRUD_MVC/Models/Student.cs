using System.ComponentModel.DataAnnotations;

namespace Student_CRUD_MVC.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public  int Roll { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Percentage { get; set; }
        [Required]

        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
