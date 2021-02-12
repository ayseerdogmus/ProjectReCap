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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //CarTest(carManager,brandManager);
            //BrandTest(brandManager);
            //ColorTest(colorManager);
            //UserTest(userManager);
            //CustomerTest(customerManager);
            //RentalTest(rentalManager);
            //Console.WriteLine("Bütün arabalar ");
            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine("Araba Id: "+car.CarId + "  Marka: " + car.BrandName + "  Araba Rengi: " + car.ColorName + "  Araba Modeli: " + car.ModelYear + "  Araba Günük Fiyatı: " + car.DailyPrice + "  Araba Açıklaması: " + car.Description);
            //}
            //Console.WriteLine(rentalManager.Add(new Rental { CustomerId = 1, CarId = 1, RentDate = new DateTime(2021, 01, 25), ReturnDate = new DateTime(2021, 03, 26) }).Message);
            foreach (var rental in rentalManager.GetRentalCarDetails().Data)
            {
                Console.WriteLine(rental.RentalId + "  " + rental.FirstName + "  " + rental.LastName + "  "
                    + rental.CompanyName + "  " + rental.Email + "  " + rental.BrandName + "  " + rental.ModelYear + "  " + rental.RentDate + "  " + rental.ReturnDate);
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
        private static void UserTest(UserManager userManager)
        {
            if (userManager.GetAll().Data.Count!=0)
            {
                Console.WriteLine("Bütün kullanıcılar");
                foreach (var user in userManager.GetAll().Data)
                {
                    Console.WriteLine(user.Id + "  " + user.FirstName + "  " + user.LastName + "  " + user.Email);
                }
            }
            else
            {
                Console.WriteLine("Henüz hiç kullanıcı yok!");
            }
            
            userManager.Add(new User { FirstName="Ayşe",LastName="Ebiçliğlu",Email="ayse@ayse.com",Password="123" });
            userManager.Add(new User { FirstName = "Reyyan", LastName = "Ebiçliğlu", Email = "reyyan@reyyan.com", Password = "123" });

            Console.WriteLine("Eklemeden sonra bütün kullanıcılar");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + "  " + user.FirstName + "  " + user.LastName + "  " + user.Email);
            }

            userManager.Update(new User {
                Id=1,
                FirstName = "Bilge",
                LastName = "Ebiçliğlu",
                Email = "bilge@bilge.com",
                Password = "123" });
            Console.WriteLine("Güncellemeden sonra bütün kullanıcılar");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + "  " + user.FirstName + "  " + user.LastName + "  " + user.Email);
            }

            userManager.Delete(new User { Id = 1 });
            Console.WriteLine("Silmeden sonra bütün kullanıcılar");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + "  " + user.FirstName + "  " + user.LastName + "  " + user.Email);
            }

        }

        private static void CustomerTest(CustomerManager customerManager)
        {
            if (customerManager.GetAll().Data.Count != 0)
            {
                Console.WriteLine("Bütün müşteriler");
                foreach (var customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine(customer.CustomerId + "  " + customer.UserId + "  " + customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine("Henüz hiç müşteri yok!");
            }

            customerManager.Add(new Customer { UserId=2 ,CompanyName="AyseCompany" }); 
            customerManager.Add(new Customer { UserId= 2, CompanyName = "BilgeCompany" });

            Console.WriteLine("Eklemeden sonra bütün müşteriler");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + "  " + customer.UserId + "  " + customer.CompanyName);
            }

            customerManager.Update(new Customer
            {
                CustomerId=2,
                UserId=2,
                CompanyName="UpdatedCompany"
               
            });
            Console.WriteLine("Güncellemeden sonra bütün müşteriler");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + "  " + customer.UserId + "  " + customer.CompanyName);
            }

            customerManager.Delete(new Customer { CustomerId = 2 });
            Console.WriteLine("Silmeden sonra bütün müşteriler");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + "  " + customer.UserId + "  " + customer.CompanyName);
            }

        }

        private static void RentalTest(RentalManager rentalManager)
        {
            if (rentalManager.GetAll().Data.Count != 0)
            {
                Console.WriteLine("Bütün kiralanmış arabalar");
                foreach (var rental in rentalManager.GetAll().Data)
                {
                    Console.WriteLine(rental.Id + "  " + rental.CustomerId + "  " + rental.CarId + "  " + rental.RentDate + "  " + rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine("Henüz hiç araba kiralanmamış");
            }
            
            rentalManager.Add(new Rental { CustomerId = 1, CarId = 2, RentDate = new DateTime(2020, 10, 25), ReturnDate = new DateTime(2020, 10, 26) });
            rentalManager.Add(new Rental { CustomerId = 1, CarId = 2, RentDate = new DateTime(2020, 11, 20), ReturnDate = new DateTime(2015, 11, 21) });

            Console.WriteLine("Eklemeden sonra bütün kiralanmış arabalar");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + "  " + rental.CustomerId + "  " + rental.CarId + "  " + rental.RentDate + "  " + rental.RentDate);
            }

            rentalManager.Update(new Rental
            {
                Id=2,
                CarId=2,
                RentDate= new DateTime(2021, 01, 01),
                ReturnDate= new DateTime(2020, 12, 02)

            });
            Console.WriteLine("Güncellemeden sonra bütün kiralanmış arabalar");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + "  " + rental.CustomerId + "  " + rental.CarId + "  " + rental.RentDate + "  " + rental.RentDate);
            }


            rentalManager.Delete(new Rental { Id=2});
            Console.WriteLine("Silmeden sonra kiralanmış arabalar");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + "  " + rental.CustomerId + "  " + rental.CarId + "  " + rental.RentDate + "  " + rental.RentDate);
            }

            foreach (var rental in rentalManager.GetRentalCarDetails().Data)
            {
                Console.WriteLine(rental.RentalId + "  " + rental.FirstName + "  " + rental.LastName + "  " 
                    + rental.CompanyName + "  " + rental.Email + "  " + rental.BrandName + "  " + rental.ModelYear + "  " + rental.RentDate + "  " + rental.ReturnDate);
            }

        }

    }
}
