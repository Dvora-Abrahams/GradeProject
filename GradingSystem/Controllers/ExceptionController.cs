using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GradeDO.Exceptions;

namespace GradingSystem.Controllers
{
    public class ExceptionController : Controller
    {
        private readonly ILogger logger;
        public ExceptionController(ILogger<ExceptionController> _logger)
        {
            logger = _logger;
        }
        [HttpGet("/error")]
        [HttpPost("/error")]
        [HttpPut("/error")]
        [HttpDelete("/error")]
        public IActionResult HandleError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionDetails != null)
            {
                logger.LogInformation("*********************************************************************");
                logger.LogError(exceptionDetails.Error.Message, "error was throwed");
                logger.LogDebug(exceptionDetails.Error, "");
                logger.LogInformation("*********************************************************************");
            }
           

            if (exceptionDetails?.Error is StudentAlradyExsistException StuEx)
            {
                logger.LogInformation("*********************************************************************");
                logger.LogWarning("Student alrady exsist");
                logger.LogInformation("*********************************************************************");
                return Problem(
                
                title: "Student alrady exsist",
                statusCode: StuEx.StatusCode
                );

            }
            if (exceptionDetails?.Error is StudentNotExsistException AnsE)
            {
                logger.LogInformation("*********************************************************************");

                logger.LogWarning("Student not exsist");
                logger.LogInformation("*********************************************************************");

                return Problem(
               
                title: "Student not exsist",
                statusCode: AnsE.StatusCode
                );

            }
            if (exceptionDetails?.Error is PasswordException PassEx)
            {
                logger.LogInformation("*********************************************************************");

                logger.LogWarning("The Password is incorrect");
                logger.LogInformation("*********************************************************************");

                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "The Password is incorrect",
                statusCode: PassEx.StatusCode
                );

            }

            if (exceptionDetails?.Error is ExerciseException ExeEx)
            {
                logger.LogInformation("*********************************************************************");

                logger.LogWarning("The exercise does not exist");
                logger.LogInformation("*********************************************************************");

                return Problem(

                title: "The exercise does not exist",
                statusCode: ExeEx.StatusCode
                );

            }


            if (exceptionDetails?.Error is NullReferenceException)
            {
                return Problem(
                detail: "Please connet the owner of the website 0548535515",
                title: "An error occurred",
                statusCode: 777
                );

            }
            return Problem(
                detail: "Please restart the website agein",
                title: "An error occurred",
                statusCode: 500
            );


        }


    }
}


