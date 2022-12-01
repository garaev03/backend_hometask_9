using task_13.Services.Abstraction;
using task_13.Services.Concrets;

namespace task_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductService products = new ProductService();
            IRestoranService restorans = new RestoranService();


            restorans.Create("KFC");
            restorans.Create("Papa");
            restorans.Create("Moda");
            restorans.Create("Dominos");
            restorans.Create("BurgerKing");

            restorans.Update(1, "MC");

            restorans.Remove(3);

            restorans.GetAll();

            Console.WriteLine();

            products.Create("buggets", 12, 0, "MC");
            products.Create("nuget", 20, 5, "MC");
            products.Create("free", 6, 0, "MC");

            products.GetByIdinRestaurant(1,1);
            products.Update("MC", 1, "Nuggets");
            products.GetByIdinRestaurant(1, 1);

            products.Remove("MC",1);
            Console.WriteLine();
            products.GetAllinRestaurants("MC");


        }
    }
}