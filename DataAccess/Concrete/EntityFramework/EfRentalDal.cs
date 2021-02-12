using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalCarDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDbContext reCapProjectDbContext=new ReCapProjectDbContext())
            {
                var result = from u in reCapProjectDbContext.Users
                             join c in reCapProjectDbContext.Customers on u.Id equals c.UserId
                             join r in filter is null ? reCapProjectDbContext.Rentals : reCapProjectDbContext.Rentals.Where(filter) 
                             on c.CustomerId equals r.CustomerId
                             join ca in reCapProjectDbContext.Cars on r.CarId equals ca.CarId
                             join b in reCapProjectDbContext.Brands on ca.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 BrandName = b.BrandName,
                                 ModelYear = ca.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
