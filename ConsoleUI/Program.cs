using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal()); 
            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.CarId+" "+car.BrandId+" "+car.DailyPrice+" "+car.Description); ;
            }
            carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 9000, ModelYear = 1972,Description="High" });
            brandManager.Add(new Brand { BrandName = "Bugatti" });

            carManager.Add(new Car { BrandId = 4, ColorId = 1, DailyPrice = -2000, ModelYear = 2002, Description = "Low" });
            brandManager.Add(new Brand { BrandName = "f" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.DailyPrice + " " + car.Description); ;
            }
        }
    }
}
