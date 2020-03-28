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

        protected virtual IQueryable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            if(entity is IAuditable iAuditable){
                 iAuditable.CreatedAt = DateTime.UtcNow;
                 iAuditable.CreatedByUser = "";
                 iAuditable.UpdatedAt =  DateTime.UtcNow;
                 iAuditable.UpdatedByUser = "";
            }
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
         {
             //Update audit fields
             if(entity is IAuditable iAuditable){
                 iAuditable.UpdatedAt =  DateTime.UtcNow;
                 iAuditable.UpdatedByUser = "";
            }

            //Attach entity
            _unitOfWork.Context.Set<T>().Attach(entity);

            var entry = _unitOfWork.Context.Entry(entity);

            entry.State = EntityState.Modified;

            //Leave Created Audit fields untouched
            if(entity is IAuditable){
                entry.Property(x => (x as IAuditable).CreatedAt).IsModified = false;
                entry.Property(x => (x as IAuditable).CreatedByUser).IsModified = false;
            }

        }
        public virtual void Delete(long Id, bool throwExceptionIfNotFound =false)
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