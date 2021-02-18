using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var resultIsCarDelivered = IsCarDelivered(rental);
            if (resultIsCarDelivered.Data==true)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(resultIsCarDelivered.Message);
            }
            else
            {
                return new ErrorResult(resultIsCarDelivered.Message);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalCarDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalCarDetails(filter), Messages.Listed);
        }

        public IDataResult<bool> IsCarDelivered(Rental rental)
        {
            var isCarDeliveredList=_rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (isCarDeliveredList.Count!=0)
            {
                foreach (var car in isCarDeliveredList)
                {                
                    if (car.ReturnDate==null || car.ReturnDate > DateTime.Now)
                    {
                        return new ErrorDataResult<bool>(false, Messages.CarNotAvailable);
                        
                    }
                }
                return new SuccessDataResult<bool>(true, Messages.CarAvailable);
            }

            return new SuccessDataResult<bool>(true, Messages.CarAvailable);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
