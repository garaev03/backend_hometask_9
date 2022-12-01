using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_13.Models
{
    internal class Restoran
    {
        public  Product[] products = new Product[0];
        static public int Id = 0;
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
