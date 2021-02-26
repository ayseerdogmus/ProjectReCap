using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesCount( carImage.CarId), ExtensionCheck(carImage.ImagePath));

            if (result!=null)
            {
                return result;
            }

                string imagePath = CreateCarImagePath(carImage.ImagePath).Data.ImagePath;            
                File.Copy(carImage.ImagePath,imagePath);
                carImage.ImagePath = imagePath;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.Added);
            
         
        }

       

        public IResult Delete(CarImage carImage)
        {
            var getCarImage = _carImageDal.GetAll(c => c.Id == carImage.Id);
            File.Delete(getCarImage[0].ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }
       
        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExist(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = "E:\\vs2019projeler\\ReCapProject\\CarImages\\logo.jpg" } });
            }
            var carImagesList = _carImageDal.GetAll(c => c.CarId == carId);


            return new SuccessDataResult<List<CarImage>>(carImagesList);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImage.CarId), ExtensionCheck(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

           
            string imagePath = CreateCarImagePath(carImage.ImagePath).Data.ToString();
            File.Copy(carImage.ImagePath, imagePath);
            File.Delete(carImage.ImagePath);
            carImage.ImagePath = imagePath;
            carImage.Date = DateTime.Now; 
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }
        private IDataResult<CarImage> CreateCarImagePath(string carImagePath)
        {
            string guidKey = Guid.NewGuid().ToString();

            string pathName = guidKey + Path.GetExtension(carImagePath);
            string imagePath = Environment.CurrentDirectory+"\\" +"CarImages"+"\\" + pathName;
            return new SuccessDataResult<CarImage>( new CarImage { ImagePath=imagePath});

        }

        private IResult ExtensionCheck(string carImagePath)
        {
            string[] extensions = { ".jpg", "jpeg", ".png" };
            if (Array.IndexOf(extensions, Path.GetExtension(carImagePath).ToLower()) == -1)
            {
                return new ErrorResult(Messages.NotSuitableExtension);
            }
            return new SuccessResult();
        }
        private IResult CheckCarImagesCount(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count > 5)
            {
                return new ErrorResult(Messages.CarImagesCountError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageExist(int carId)
        {
            var carImagesList = _carImageDal.GetAll(c => c.CarId == carId);
            if (carImagesList.Count==0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            return new SuccessDataResult<List<CarImage>>();
        }

      
    }
}
