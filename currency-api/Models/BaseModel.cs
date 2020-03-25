using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public abstract class BaseModel {
        public long Id {get;set;}
        public DateTime? CreatedAt {get;set;}
        public string CreatedByUser {get;set;}
        public DateTime? UpdatedAt {get;set;}
        public string UpdatedByUser {get;set;}
        public bool IsActive {get;set;}
        public bool IsDeleted {get;set;}
    }

    public class BaseModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
             builder.Property(r => r.Id).ValueGeneratedOnAdd();  
        }
    }
}
