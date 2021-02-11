using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRepositoryService<T> where T : class,IEntity, new()
    {
        IResult Add(T entiy);
        IResult Update(T brand);
        IResult Delete(T entiy);
        IDataResult<List<T>> GetAll();
    }
}
