using GradeDO;
using GradeDO.Exceptions;
using GradingSystem.Configurations;
using GradingSystem.Models;
using Microsoft.Extensions.Options;

namespace GradingSystem.Services
{
    public class PasswordManager : IPasswordManager
    {
         Teacher teacher;
         IStudents students;
        public PasswordManager(IOptions<Teacher> _teacher, IStudents _students)
        {
            teacher = _teacher.Value;
            students = _students;
        }

        public bool ValideNameAndPassword(string id, string password)
        {
            foreach (Student student in students.ViewStudents())
            {
                if (student.ID.Equals(id))
                {
                    if (!student.Password.Equals(password))
                        throw new PasswordException();
                    return true;
                }
            }
            if (id.Equals(teacher.Name))
            {
                if (!teacher.Password.Equals(password))
                    throw new PasswordException();
                return true;
                
            }
            throw new StudentNotExsistException(id);
        }
    }
}
