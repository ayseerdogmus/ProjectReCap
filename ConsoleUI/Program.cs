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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //CarTest(carManager,brandManager);
            //BrandTest(brandManager);
            //ColorTest(colorManager);
            Console.WriteLine("Bütün arabalar ");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araba Id: "+car.CarId + "  Marka: " + car.BrandName + "  Araba Rengi: " + car.ColorName + "  Araba Modeli: " + car.ModelYear + "  Araba Günük Fiyatı: " + car.DailyPrice + "  Araba Açıklaması: " + car.Description);
            }
        }

        private static void CarTest(CarManager carManager, BrandManager brandManager)
        {
            Console.WriteLine("BrandId'ye göre arabalar (3)");
            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.DailyPrice + " " + car.Description); 
            }

            Console.WriteLine("ColorId'ye göre arabalar (2)");
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.CarId + " " + car.ColorId + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("Bütün arabalar");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.DailyPrice + "  " + car.Description); 
            }
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 5555, ModelYear = 1955, Description = "Low" });
            brandManager.Add(new Brand { BrandName = "Bugatti" });

            carManager.Add(new Car { BrandId = 4, ColorId = 1, DailyPrice = -2000, ModelYear = 2002, Description = "Low" });
            brandManager.Add(new Brand { BrandName = "f" });

            Console.WriteLine("Eklemeden sonra bütün arabalar");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.DailyPrice + "  " + car.Description);
            }

            carManager.Update(new Car {CarId=9, BrandId = 1, ColorId = 3, DailyPrice = 9999, ModelYear = 2010, Description = "Middle" });
            Console.WriteLine("Güncellemeden sonra bütün arabalar");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.DailyPrice + "  " + car.Description);
            }

            carManager.Delete(new Car { CarId = 6 });
            Console.WriteLine("Silmeden sonra bütün arabalar");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.DailyPrice + "  " + car.Description);
            }

            

        }

        private static void BrandTest( BrandManager brandManager)
        {
            Console.WriteLine("BrandId'ye göre markalar (2)");
            var brandGetById = brandManager.GetById(2).Data;
            Console.WriteLine("BrandId={0} BrandName={1}",brandGetById.BrandId,brandGetById.BrandName);

          

            Console.WriteLine("Bütün markalar");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "  " + brand.BrandName);
            }
            brandManager.Add(new Brand { BrandName = "Alfa Romeo" });

            Console.WriteLine("Eklemeden sonra bütün markalar");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "  " + brand.BrandName);
            }

            brandManager.Update(new Brand { BrandId =4, BrandName= "Cadillac" });
            Console.WriteLine("Güncellemeden sonra bütün markalar");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "  " + brand.BrandName);
            }

            brandManager.Delete(new Brand { BrandId =5 });
            Console.WriteLine("Silmeden sonra bütün markalar");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "  " + brand.BrandName);
            }



        }

        private static void ColorTest(ColorManager colorManager)
        {
            Console.WriteLine("ColorId'ye göre renkler (1)");
            var colorGetById = colorManager.GetById(1).Data;
            Console.WriteLine("ColorId={0} ColorName={1}", colorGetById.ColorId, colorGetById.ColorName);



            Console.WriteLine("Bütün renkler");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "  " + color.ColorName);
            }
            colorManager.Add(new Color { ColorName = "Silver" });

            Console.WriteLine("Eklemeden sonra bütün renkler");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "  " + color.ColorName);
            }

            colorManager.Update(new Color { ColorId = 4, ColorName = "Black" });
            Console.WriteLine("Güncellemeden sonra bütün renkler");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "  " + color.ColorName);
            }

            colorManager.Delete(new Color { ColorId = 5 });
            Console.WriteLine("Silmeden sonra bütün renkler");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "  " + color.ColorName);
            }



        }


    }
}
