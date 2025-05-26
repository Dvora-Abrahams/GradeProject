using GradeDO;
using GradingSystem.Models;
using GradingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementController : Controller
    {
        IStudents students;
        IPasswordManager passwordManager;
        ILogger<StudentManagementController> logger;
        public StudentManagementController(IStudents _students, IPasswordManager _passwordManager, ILogger<StudentManagementController> _logger)
        {
            students = _students;
            passwordManager = _passwordManager;
            logger = _logger;
        }
        [HttpPost("Add")]
        public string Add_Student([FromQuery][Bind("ID" ,"Name")] M_Student student)
        {
            students.AddStudent(student.Convert());
            logger.LogInformation($"the teacher connect and add student with the id: {student.ID} and the name:{student.Name}");
            return "The student was added successfully.";

        }
        [HttpDelete]
        public string Erease_Student(string studentId)
        {
            students.EreaseStudent(studentId);
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the teacher connect and delete student with the id: {studentId}");
            logger.LogInformation("*********************************************************************");
            return "The student was successfully deleted.";

        }

        [HttpPost("EditPassword")]
        public string Edit_Password( [FromForm]string studentId, [FromForm] string currPassword, [FromForm] string newPassword)
        {
            if (passwordManager.ValideNameAndPassword(studentId, currPassword))
            {
                students.EditPassword(studentId, newPassword);
                logger.LogInformation("*********************************************************************");
                logger.LogInformation($"the teacher connect and edit the password to the student with the id: {studentId} ");
                logger.LogInformation("*********************************************************************");
                return "Password successfully set.";
            }
            return "";
        }

        [HttpPost("EditName")]
        public string Edit_Name([FromForm] string studentId, [FromForm] string newName, [FromForm] string password)
        {
            if (passwordManager.ValideNameAndPassword(studentId, password))
            {
                students.EditName(studentId, newName, password);
                logger.LogInformation("*********************************************************************");
                logger.LogInformation($"the teacher connect and edit the name to the student with the id: {studentId} ");
                logger.LogInformation("*********************************************************************");
                return "Name successfully set.";
            }
            return "";
            
        }

        [HttpGet]
        public List<Student> Get_Students()
        {
            List<Student> ret = students.ViewStudents();
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the teacher connect and print all the students");
            logger.LogInformation("*********************************************************************");
            return ret;
        }

        [HttpGet("{StudentId}")]
        public Student Get_Student([FromRoute] string StudentId)
        {
            Student ret = students.ViewStudent(StudentId);
            logger.LogInformation("*********************************************************************");
            logger.LogInformation($"the teacher connect and print the student with the id: {StudentId}");
            logger.LogInformation("*********************************************************************");
            return ret;

        }

    }
}
