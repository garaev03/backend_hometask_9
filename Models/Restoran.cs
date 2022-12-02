using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_13.Services.Utilities.Exceptions;

namespace task_13.Models
{
    internal class Restoran
    {
        private string _name;


        public Product[] products = new Product[0];
        static public int Id = 0;
        public int ID { get; set; }
        public string Name
        {
            get => _name; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidInputException("Invalid input from user.");
                _name = value;
            }
        }

    }
}
