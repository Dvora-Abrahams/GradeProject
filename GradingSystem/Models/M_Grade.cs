using GradeDO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GradingSystem.Models
{
    public class M_Grade
    {
        [Range(0,99)]
        [Required]
        public int ExeNumber { get; set; }
        
        public int GradeNumber { get; set; }
       [MinLength(2)]
        public string Comment { get; set; }


        public Grade Convert()
        {
            return new Grade() { 
                ExeNumber = ExeNumber ,
                Date=DateTime.Now,
                GradeNumber=GradeNumber,
                Comment = Comment };
        }
    }
}
