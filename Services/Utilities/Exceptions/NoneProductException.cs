using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_13.Services.Utilities.Exceptions
{
    public class NoneProductException : Exception
    {
        public NoneProductException()
        {
            Console.WriteLine("None product detected.");
        }
    }
}
