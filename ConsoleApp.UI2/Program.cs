using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleApp.UI2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetCarDetails();
            Console.WriteLine("ID   BrandId   ColorId   ModelYear   Price   Description");
            foreach (var item in cars)
            {
            
                Console.WriteLine(item.CarId + "   " + item.BrandName + "   " + item.ColorName  + "   " + item.Price + "   " + item.Description);
            }
        }
    }
}
