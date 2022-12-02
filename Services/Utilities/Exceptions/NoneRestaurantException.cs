using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_13.Services.Utilities.Exceptions
{
    public class NoneRestaurantException:Exception
    {
        public NoneRestaurantException()
        {
            Console.WriteLine("None restaurant detected.");
        }
    }
}
