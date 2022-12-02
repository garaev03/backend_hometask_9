using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_13.Services.Abstraction
{
    internal interface IProductService
    {
        public void Create( string name, double price, double discountedPrice, string resName);
        public void Remove(int resId,int id);
        public void Update(int resId, int prodId);
        public void GetAllinRestaurants(int resId);
        public void GetByIdinRestaurant(int resId, int prodId);
    }
}
