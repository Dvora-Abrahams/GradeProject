using GradeDO;
using Microsoft.AspNetCore.Mvc;
using GradingSystem.Models;
using Microsoft.AspNetCore.Http;
using GradingSystem.Services;
using GradingSystem.Configurations;
using Microsoft.Extensions.Options;
using System;
using GradeDO.Exceptions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesManagementController : ControllerBase
    {
        IStudents students;
        IGradeManagement gradeManagement;
        Percents percents;
        ILogger<GradesManagementController> logger;
        public GradesManagementController(IStudents _students,IGradeManagement _gradeManagement, IOptions<Percents> _percents, ILogger<GradesManagementController> _logger)
        {
            students = _students;
            gradeManagement = _gradeManagement;
            percents = _percents.Value;
            logger = _logger;
        }
        [HttpPut("InsertGrades")]
        public string Insert_Grades(int exeNum,[FromBody] [Bind("Ids", "Grades")] StudentsAndGrades studentsAndGrades) {
            
            students.InsertGrades(studentsAndGrades.Ids, studentsAndGrades.Grades, exeNum);
            if (percents.Exepercents.Count()-1 < exeNum)
                percents.Exepercents.Add(0);
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the teacher insert grade for exe{exeNum} to all students");
            logger.LogInformation("*********************************************************************");
            return "The grades were successfully entered for all the students.";
        }

        [HttpPost("EditGrade")]
        public string Edit_Grade([FromForm]string studentId, [FromForm] int grade, [FromForm] int exeNum)
        {
            students.EditGrade(studentId, grade, exeNum);
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the teacher edit grade of exe{exeNum} change to {grade} for student {studentId}");
            logger.LogInformation("*********************************************************************");
            return "The score was successfully compiled.";
        }

        [HttpGet("{exeNumber}")]
        public List<int> Return_Grades([FromRoute] int exeNumber)
        {
            if(exeNumber>percents.Exepercents.Count())
                 throw new ExerciseException(exeNumber);
            List<int> ret = students.ReturnGrades(exeNumber);
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"return all grade for exe{exeNumber} to the teacher");
            logger.LogInformation("*********************************************************************");
            return ret;
        }

        [HttpGet("FinalGrades")]
        public Dictionary<string,float> Final_Grades()
        {
            Dictionary<string, float> ret = gradeManagement.FinalGrades();
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"return final grades for all students to the teacher");
            logger.LogInformation("*********************************************************************");
            return ret;
        }

        [HttpGet("ReturnAllGrades")]
        public Dictionary<int, List<int>> Return_All_Grades()
        {
            Dictionary<int, List<int>> ret = students.ReturnAllGrades(percents.Exepercents.Count());
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"return all grades for all students to the teacher");
            logger.LogInformation("*********************************************************************");
            return ret;
        }







    }
}
