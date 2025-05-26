using GradeDO;
using GradeDO.Exceptions;
using GradingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewGradesController : ControllerBase
    {
        IStudents students;
        IGradeManagement gradeManagement;
        IPasswordManager passwordManager;
        ILogger<ViewGradesController> logger;
        public ViewGradesController(IStudents _students,IGradeManagement _gradeManagement,IPasswordManager _passwordManager, ILogger<ViewGradesController> _logger)
        {
            students = _students;
            gradeManagement = _gradeManagement;
            passwordManager = _passwordManager;
            logger=_logger;
            
        }
        
        [HttpGet ("LastSubmit")]
        public Dictionary<string,float> Last_Submit(string studentId, string passWord)
        {
            Dictionary<string,float> dict = new Dictionary<string,float>();
            
            if (passwordManager.ValideNameAndPassword(studentId, passWord))
            {
                Grade g = students.LastSubmit(studentId, passWord);
                dict["lastsubmit"] = g.GradeNumber;
                dict["avarage"] = gradeManagement.ExerciseAverage(g.ExeNumber);
            }
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the student with the id:{studentId} connect and get the last grade");
            logger.LogInformation("*********************************************************************");
            return dict;
        }

        [HttpGet("SpecificExe")]
        public Dictionary<string, float> Specific_Exe(string studentId,  string passWord,  int exeNum)
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();
           
            if (passwordManager.ValideNameAndPassword(studentId, passWord))
            {
                Grade g = students.SpecificExercise(studentId, exeNum);
                if (g == null)
                    throw new ExerciseException(exeNum);
                dict["grade"] = g.GradeNumber;
                    dict["avarage"] = gradeManagement.ExerciseAverage(g.ExeNumber) ;
             
            }
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the student with the id:{studentId} connect and get the exercise {exeNum}");
            logger.LogInformation("*********************************************************************");
            return dict ;
              
        }

        [HttpGet("ViewTest")]
        public Dictionary<string, float> View_Test(string studentId, string passWord)
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();
            if (passwordManager.ValideNameAndPassword(studentId, passWord))
            {
                Grade g = students.SpecificExercise(studentId,99);
                if (g == null)
                    throw new ExerciseException(99);
                dict["grade"] = g.GradeNumber;
                dict["avarage"] = gradeManagement.ExerciseAverage(g.ExeNumber); ;
                logger.LogInformation("*********************************************************************");
                logger.LogInformation($"the student with the id:{studentId} connect and get test grade");
                logger.LogInformation("*********************************************************************");
                
            }
            return dict;
        }

        [HttpGet("FinalGrade")]
        public float Final_Grade(string studentId)
        {
            float ret = gradeManagement.FinalGrade(studentId);
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the student with the id:{studentId} connect and get the final grade");
            logger.LogInformation("*********************************************************************");
            return ret;
        }
    }
}
