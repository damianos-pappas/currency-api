using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using currencyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace currencyApi.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        protected IQueryable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>();
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(long Id, bool throwExceptionIfNotFound =false)
        {
            T existingEntity = _unitOfWork.Context.Set<T>().Find(Id);
            
            if (existingEntity == null )
            {
                if(throwExceptionIfNotFound)
                     throw new Exception("Entity Not Found");
                else
                    return;
            }

            if(typeof(ISoftDelete).IsAssignableFrom(typeof(T)))
                (existingEntity as ISoftDelete).IsDeleted = true;
            else
                _unitOfWork.Context.Set<T>().Remove(existingEntity);
        }
    }
}