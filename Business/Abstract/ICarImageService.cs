using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService: IRepositoryService<CarImage>
    {
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);

    }
}
