using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=6,DailyPrice=500,Description="Orta Segment",ModelYear=2010},
            new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=1500,Description="Yüksek Segment",ModelYear=2020},
            new Car{CarId=3,BrandId=2,ColorId=1,DailyPrice=1800,Description="Yüksek Segment",ModelYear=2020},
            new Car{CarId=4,BrandId=3,ColorId=3,DailyPrice=100,Description="Düşük Segment",ModelYear=2001},
            new Car{CarId=5,BrandId=3,ColorId=16,DailyPrice=700,Description="Orta Segment",ModelYear=2018}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete=null;

            //LINQ
            carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            //LINQ
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
