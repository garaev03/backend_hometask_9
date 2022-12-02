using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using task_13.Models;
using task_13.Services.Abstraction;
using task_13.Services.Utilities.Exceptions;

namespace task_13.Services.Concrets
{
    internal class RestoranService : IRestoranService
    {
        public static Restoran[] Restorans = { };
        public void Create(string name)
        {
            Restoran restoran = new Restoran();
            restoran.Name = name;
            Restoran.Id++;
            restoran.ID = Restoran.Id;
            Array.Resize(ref Restorans, Restorans.Length + 1);
            Restorans[Restorans.Length - 1] = restoran;
        }

        public void GetAll()
        {
            Console.WriteLine("\nRestaurants:");
            foreach (var restaurant in Restorans)
            {
                Console.WriteLine($"ID: {restaurant.ID} -> Name: {restaurant.Name}");
            }
        }

        public Restoran GetById(int id)
        {
            for (int i = 0; i < Restorans.Length; i++)
            {
                if (Restorans[i].ID == id)
                    return Restorans[i];
            }
            throw new NoneRestaurantException();
        }

        public void Remove(int id)
        {
            for (int i = 0; i < Restorans.Length; i++)
            {
                if (id == Restorans[i].ID)
                {
                    Restorans[i] = Restorans[Restorans.Length - 1];
                    Array.Resize(ref Restorans, Restorans.Length - 1);
                    return;
                }
            }
            throw new NoneRestaurantException();
        }

        public void Update(int id, string newName)
        {
            foreach (var restaurant in Restorans)
            {
                if (restaurant.ID == id)
                {
                    restaurant.Name = newName;
                    return;
                }
            }
            throw new NoneRestaurantException();
        }
    }
}
