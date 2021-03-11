
using ReCapProject.Business.Concrete;

using ReCapProject.DataAccess.Concrete.EntityFramework;
using System;


namespace ConsoleApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetAll();
            foreach (var item in  cars)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
