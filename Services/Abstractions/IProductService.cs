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
        public void Remove(string Name,int id);
        public void Update(string resName, int id, string newProdName);
        public void GetAllinRestaurants(string resName);
        public void GetByIdinRestaurant(int resId, int prodId);
    }
}
