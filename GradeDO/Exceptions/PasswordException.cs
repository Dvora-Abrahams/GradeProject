using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class PasswordException:Exception
    {
        public PasswordException(): base($"The password is incorrect")
        {

        }
        public int? StatusCode { get; } = 442;

    
}
}
