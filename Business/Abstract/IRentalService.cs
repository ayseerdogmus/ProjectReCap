using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService:IRepositoryService<Rental>
    {
        IDataResult<bool> IsCarDelivered(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalCarDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
