using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context=new ReCapProjectDbContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars on b.BrandId equals c.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto 
                             { 
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();
            }
            
        }
    }
}
