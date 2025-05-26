using GradeDO;
using System.ComponentModel.DataAnnotations;

namespace GradingSystem.Models
{
    public class M_Student
    {
        [MaxLength(9)]
        [Required]
        public string ID { get; set; } 
        [MinLength(3)]
        public string Name { get; set; } 


        public Student Convert()
        {
            return new Student()
            {
                ID = ID,
                Name = Name,
                Password = ID,
                ExeList = new List<Grade>(),
                TestGrade=new Grade(),

            };
        }
    }
}
