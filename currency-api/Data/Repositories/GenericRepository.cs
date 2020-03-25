using System;
using System.Collections.Generic;
using System.Linq;
using currencyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace currencyApi.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(long Id, bool safeDelete =false)
        {
            T existingEntity = _unitOfWork.Context.Set<T>().Find(Id);
            
            if (existingEntity == null && !safeDelete)
                throw new Exception("Entity Not Found");

            if(typeof(ISoftDelete).IsAssignableFrom(typeof(T)))
                (existingEntity as ISoftDelete).IsDeleted = true;
            else
                _unitOfWork.Context.Set<T>().Remove(existingEntity);
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }

        public T Get(long Id)
        {
            return _unitOfWork.Context.Set<T>().Find(Id);
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public void Update(T entity)
        {
             _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}