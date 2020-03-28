using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace currencyApi.Data
{
    public interface IGenericRepository<T> where T : class
    {
        //the get method is  exposed only to the generic repository's children
        void Add(T entity);
        void Delete(long Id, bool safeDelete = false);
        void Update(T entity);
    }
}