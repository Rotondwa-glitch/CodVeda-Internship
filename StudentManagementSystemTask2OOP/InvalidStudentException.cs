using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemTask2OOP
{

    using System;

    public class InvalidStudentException : Exception
    {
        public InvalidStudentException(string message)
            : base(message)
        {
        }
    }

}
