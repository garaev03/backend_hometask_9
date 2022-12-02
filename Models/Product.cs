using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_13.Services.Utilities.Exceptions;

namespace task_13.Models
{
    internal class Product
    {
        private string _name;
        private double _price;
        private double _discountedPrice;



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
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new InvalidInputException("Invalid input from user.");
                _price = value;
            }
        }
        public double DiscountPrice
        {
            get => _discountedPrice;
            set
            {
                if (value < 0)
                    throw new InvalidInputException("Invalid input from user.");
                _discountedPrice = value;
            }
        }
    }
}
