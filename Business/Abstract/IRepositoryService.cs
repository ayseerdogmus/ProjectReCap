using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRepositoryService<T> where T : class,IEntity, new()
    {
        void Add(T entiy);
        void Update(T brand);
        void Delete(T entiy);
        List<T> GetAll();
    }
}
