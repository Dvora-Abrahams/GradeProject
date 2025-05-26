using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class StudentNotExsistException : Exception
    {
        public StudentNotExsistException(string StudentId):base($"The student with Id {StudentId} not exsist")
        {
            
        }
        public int? StatusCode { get;  } = 444;
        
    }
    public class StudentAlradyExsistException  : Exception
    {
        public StudentAlradyExsistException(string StudentId) : base($"The student with Id {StudentId} aleady exsist")
        {

        }
        public int? StatusCode { get;  } = 443;

    }
}
