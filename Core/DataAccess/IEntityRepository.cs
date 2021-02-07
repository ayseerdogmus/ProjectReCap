using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Core katmanında istenilen katman ayrı ayrı lasörlenip implement edilir!!!
    //Core katmanı diğer katmanları referans almaz
    //class:referans tip
    //IEntity : ya IEntity olur ya da IEntity'yi implement eden sınıflar olur.
    //new()::New'lenebilir olmak zorunda bu sayede IEntity kabul olmaz çünkü interface

    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//filter=null filtre vermeyebilirsin!
        T Get(Expression<Func<T, bool>> filter);//filtre zorunlu!
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
