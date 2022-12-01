using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_13.Services.Utilities.Exceptions
{
    public class NoneProductsException:Exception
    {
        public NoneProductsException()
        {
            Console.WriteLine("There is no product in restaurant.");
        }
    }
}
