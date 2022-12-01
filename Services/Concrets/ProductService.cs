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
            throw new InvalidInputException();
        }

        public void GetAllinRestaurants(string resName)
        {
            foreach (var restaurant in RestoranService.Restorans)
            {
                if (restaurant.Name == resName)
                {
                    Console.WriteLine($"Products in {resName}:\n");
                    for (int i = 0; i < restaurant.products.Length; i++)
                    {
                        Console.WriteLine($"Product Id: {restaurant.products[i].ID} \nName: {restaurant.products[i].Name} \nPrice: {restaurant.products[i].Price} \nDiscounted Price: {restaurant.products[i].DiscountPrice}\n");
                    }
                }
            }
        }

        public void GetByIdinRestaurant(int resId, int prodId)
        {
            foreach (var restoran in RestoranService.Restorans)
            {
                if (restoran.ID == resId)
                {
                    for (int i = 0; i < restoran.products.Length; i++)
                    {
                        if (restoran.products[i].ID == prodId)
                        {
                            Console.WriteLine($"Product name: {restoran.products[i].Name}");
                            return;
                        }
                    }
                }
            }
            throw new InvalidInputException();
        }

        public void Remove(string Name,int id)
        {
            foreach (var restoran in RestoranService.Restorans)
            {
                if (restoran.Name == Name)
                {
                    for (int i = 0; i < restoran.products.Length; i++)
                    {
                        if (restoran.products[i].ID == id)
                        {
                            var clip = restoran.products[restoran.products.Length-1];
                            restoran.products[i] = clip;
                            Array.Resize(ref restoran.products, restoran.products.Length - 1);
                            return;
                        }
                    }
                }
            }
            throw new InvalidInputException();
        }

        public void Update(string resName, int id, string newProdName)
        {
            foreach (var restaurant in RestoranService.Restorans)
            {
                if (restaurant.Name == resName)
                {
                    for (int i = 0; i < restaurant.products.Length; i++)
                    {
                        if (restaurant.products[i].ID == id)
                        {
                            restaurant.products[i].Name = newProdName;
                            return;
                        }
                    }
                }
            }
            throw new InvalidInputException();
        }

        public double DiscountCalc(double discount,double price)
                =>price-(price*discount)/100;
    }
}
