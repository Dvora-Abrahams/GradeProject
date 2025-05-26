using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class ExerciseException : Exception
    {
        public ExerciseException(int num) : base($"The exercise: {num} does not exist")
        {

        }
        public int? StatusCode { get; } = 441;
    }


    public class EmptyExeList : Exception
    {
        public EmptyExeList() : base($"The exercise list is empty")
        {

        }
        public int? StatusCode { get; } = 440;
    }
}

