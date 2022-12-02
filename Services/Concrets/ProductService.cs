using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_13.Models;
using task_13.Services.Abstraction;
using task_13.Services.Utilities.Exceptions;

namespace task_13.Services.Concrets
{
    internal class ProductService : IProductService
    {
        public void Create(string name, double price, double discountedPrice, string resName)
        {
            Product product = new Product();
            foreach (var restaurant in RestoranService.Restorans)
            {
                if (restaurant.Name == resName)
                {
                    product.DiscountPrice = discountedPrice;
                    product.Price = DiscountCalc(discountedPrice, price);
                    product.Name = name;
                    Product.Id++;
                    product.ID = Product.Id;
                    Array.Resize(ref restaurant.products, restaurant.products.Length + 1);
                    restaurant.products[restaurant.products.Length - 1] = product;
                    return;
                }
            }
            throw new NoneRestaurantException();
        }

        public void GetAllinRestaurants(int resId)
        {
            RestoranService restoranService = new();
            var restoran = restoranService.GetById(resId);
            Console.WriteLine($"Products in {restoran.Name}:\n");
            for (int i = 0; i < restoran.products.Length; i++)
            {
                Console.WriteLine($"Product Id: {restoran.products[i].ID} \nName: {restoran.products[i].Name} \nPrice: {restoran.products[i].Price} \nDiscounted Price: {restoran.products[i].DiscountPrice}\n");
            }
        }

        public void GetByIdinRestaurant(int resId, int prodId)
        {
            RestoranService restoranService = new();
            var restoran = restoranService.GetById(resId);
            for (int i = 0; i < restoran.products.Length; i++)
            {
                if (restoran.products[i].ID == prodId)
                {
                    Console.WriteLine($"Product name: {restoran.products[i].Name}");
                    return;
                }
            }
            throw new NoneProductException();
        }

        public void Remove(int resId, int prodId)
        {
            RestoranService restoranService = new();
            var restoran = restoranService.GetById(resId);
            for (int i = 0; i < restoran.products.Length; i++)
            {
                if (prodId == restoran.products[i].ID)
                {
                    var clip = restoran.products[restoran.products.Length - 1];
                    restoran.products[i] = clip;
                    Array.Resize(ref restoran.products, restoran.products.Length - 1);
                    return;
                }
            }
            throw new NoneProductException();

        }
  
        public void Update(int resId, int prodId)
        {
            RestoranService restoranService = new();
            var arr = restoranService.GetById(resId).products;
            foreach (var product in arr)
            {
                if (product.ID == prodId)
                {
                    Console.WriteLine($"\nSelected Product: {product.Name}");
                    Console.WriteLine("What do you want to change?\n1. Product Name\n2. Product Price\n3. Product Discount Price\n");
                    Console.Write("Enter key:"); int value = int.Parse(Console.ReadLine());
                    switch (value)
                    {
                        case 1:
                            Console.WriteLine("--Selected Product Name change--");
                            Console.Write("Enter new Name: "); product.Name = Console.ReadLine();
                            return;
                        case 2:
                            Console.WriteLine("--Selected Product Price change--");
                            Console.Write("Enter new Price: "); product.Price = Convert.ToDouble(Console.ReadLine());
                            return;
                        case 3:
                            Console.WriteLine("--Selected Product Discount Price change--");
                            Console.WriteLine("Enter new Discount Price: "); product.DiscountPrice = Convert.ToDouble(Console.ReadLine());
                            return;
                        default:
                            return;
                    }
                }
            }
            throw new NoneProductException();
        }

        public double DiscountCalc(double discount, double price)
                => price - (price * discount) / 100;
    }
}
