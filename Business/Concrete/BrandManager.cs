using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]

        public IResult Add(Brand brand)
        {
            //.Validate(new BrandValidator(), brand);
            //if (brand.BrandName.Length > 2)
            //{
                _brandDal.Add(brand);
                //Console.WriteLine("Marka eklendi.");
                return new SuccessResult(Messages.Added);
            //}
            //else
            //{
            //    //Console.WriteLine("Marka eklenemedi! Marka ismi en az 3 karakter olmalıdır. Girdiğiniz marka ismi  {0}",brand.BrandName);
            //    return new ErrorResult(Messages.AddFailed);
            //}
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka başarıyla silindi.");
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(b => b.BrandId == id));
        }

        [ValidationAspect(typeof(BrandValidator))]

        public IResult Update(Brand brand)
        {
            //ValidationTool.Validate(new BrandValidator(), brand);
            //if (brand.BrandName.Length >= 2)
            //{
                _brandDal.Update(brand);
                //Console.WriteLine("Marka güncellendi.");
                return new SuccessResult(Messages.Updated);
            //}
            //else
            //{
            //   // Console.WriteLine("Marka güncellenemedi! Marka ismi en az 3 karakter olmalıdır. Girdiğiniz marka ismi  {0}", brand.BrandName);
            //    return new ErrorResult(Messages.BrandNameInvalid);
            //}
        }
    }
}
