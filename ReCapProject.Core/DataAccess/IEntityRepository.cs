using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T TEntity);
        void Delete(T TEntity);
        void Update(T TEntity);

    }
}
