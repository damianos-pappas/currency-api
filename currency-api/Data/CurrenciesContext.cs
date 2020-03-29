using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using currencyApi.BusinessLogic.Helpers;
using currencyApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

namespace currencyApi.Data
{
    //Application's db Context
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext(DbContextOptions<CurrenciesContext> options)
            : base(options)
        {
        }

        /*******************************************************************
            DB SETS
        ********************************************************************/
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }

        /*******************************************************************
            Model DB configuration
        ********************************************************************/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(
                entity =>
                {
                    entity.ToTable("Currencies");

                    entity.HasKey(c => c.Id);

                    entity.Property(c => c.Id).ValueGeneratedOnAdd();

                    entity.HasQueryFilter(r => r.IsDeleted == false);

                    if (Database.IsInMemory())
                        entity.Property(c => c.Id).HasValueGenerator<InMemoryIntegerValueGenerator<long>>();

                    entity.HasIndex(c => c.Code).IsUnique();

                    entity.Property(c => c.Code).HasMaxLength(3)
                                               .IsFixedLength()
                                               .IsRequired();

                    entity.Property(c => c.Description).IsRequired();

                }
            );

            modelBuilder.Entity<CurrencyRate>(
                entity =>
                {
                    entity.ToTable("CurrencyRates");

                    entity.HasKey(r => r.Id);

                    entity.Property(r => r.Id).ValueGeneratedOnAdd();

                    entity.HasQueryFilter(r => r.IsDeleted == false);

                    if (Database.IsInMemory())
                        entity.Property(c => c.Id).HasValueGenerator<InMemoryIntegerValueGenerator<long>>();

                    entity.HasIndex(r => new { r.BaseCurrencyId, r.TargetCurrencyId })
                          .IsUnique();

                    entity.HasOne(r => r.BaseCurrency)
                          .WithMany(c => c.CurrencyRates)
                          .HasForeignKey(r => r.BaseCurrencyId);

                    entity.HasOne(r => r.TargetCurrency)
                          .WithMany()
                          .HasForeignKey(r => r.TargetCurrencyId);

                    entity.Property(r => r.Rate).HasColumnType("decimal(18, 10)");
                }
            );

            modelBuilder.Entity<User>(
                entity =>
                {
                    entity.ToTable("Users");

                    entity.HasKey(r => r.Id);

                    entity.Property(r => r.Id).ValueGeneratedOnAdd();

                    entity.HasQueryFilter(r => r.IsDeleted == false);

                    if (Database.IsInMemory())
                        entity.Property(c => c.Id).HasValueGenerator<InMemoryIntegerValueGenerator<long>>();
                }
            );

            modelBuilder.Entity<UserRole>(
                entity =>
                {
                    entity.ToTable("UserRoles");

                    entity.HasKey(r => r.Id);

                    entity.Property(r => r.Id).ValueGeneratedOnAdd();

                    entity.HasIndex(r => r.Description).IsUnique();

                    if (Database.IsInMemory())
                        entity.Property(c => c.Id).HasValueGenerator<InMemoryIntegerValueGenerator<long>>();
                }
            );

            modelBuilder.Entity<UserRoleRelation>(
                entity =>
                {
                    entity.ToTable("UserRoleRelations");

                    entity.HasKey(r => r.Id);

                    entity.Property(r => r.Id).ValueGeneratedOnAdd();

                    entity.HasQueryFilter(r => r.IsDeleted == false);

                    if (Database.IsInMemory())
                        entity.Property(c => c.Id).HasValueGenerator<InMemoryIntegerValueGenerator<long>>();

                    entity.HasIndex(r => new { r.UserId, r.RoleId })
                          .IsUnique();

                    entity.HasOne(r => r.User)
                          .WithMany(u => u.UserRoleRelations)
                          .HasForeignKey(r => r.UserId);

                    entity.HasOne(r => r.Role)
                          .WithMany()
                          .HasForeignKey(r => r.RoleId);
                }
            );

            /*******************************************************************
                DATA SEEDING
            ********************************************************************/
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "admin",
                   Email = "user@currencies.cur",
                   PasswordHash = EncryptionHelper.Encrypt("admin123", "this_is_a_demo_project"),
                   CreatedAt = DateTime.UtcNow,
                   IsActive = true,
                   IsDeleted = false
               },
               new User
               {
                   Id = 2,
                   UserName = "user",
                   Email = "user@currencies.cur",
                   PasswordHash = EncryptionHelper.Encrypt("user123", "this_is_a_demo_project"),
                   CreatedAt = DateTime.UtcNow,
                   IsActive = true,
                   IsDeleted = false
               }
           );

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole { Id = 1, Description = "USER_CURRENCIES_RATES" },
               new UserRole { Id = 2, Description = "ADMIN_CURRENCIES" },
               new UserRole { Id = 3, Description = "ADMIN_RATES" },
               new UserRole { Id = 4, Description = "ADMIN_USERS" }
           );

            modelBuilder.Entity<UserRoleRelation>().HasData(
                new UserRoleRelation { Id = 1, UserId = 1, RoleId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new UserRoleRelation { Id = 2, UserId = 2, RoleId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new UserRoleRelation { Id = 3, UserId = 2, RoleId = 2, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new UserRoleRelation { Id = 4, UserId = 2, RoleId = 3, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new UserRoleRelation { Id = 5, UserId = 2, RoleId = 4, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false }
            );

            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Code = "EUR", Description = "Euro", CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new Currency { Id = 2, Code = "USD", Description = "US Dollar", CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new Currency { Id = 3, Code = "CHF", Description = "Swiss Franc", CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new Currency { Id = 4, Code = "GBP", Description = "British Pound", CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new Currency { Id = 5, Code = "JPY", Description = "Japan Yen", CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new Currency { Id = 6, Code = "CAD", Description = "Canadian Dollar", CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false }
            );

            modelBuilder.Entity<CurrencyRate>().HasData(
                new CurrencyRate { Id = 1, BaseCurrencyId = 1, TargetCurrencyId = 2, Rate = 1.3764m, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new CurrencyRate { Id = 2, BaseCurrencyId = 1, TargetCurrencyId = 3, Rate = 1.2079m, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new CurrencyRate { Id = 3, BaseCurrencyId = 1, TargetCurrencyId = 4, Rate = 0.8731m, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new CurrencyRate { Id = 4, BaseCurrencyId = 2, TargetCurrencyId = 5, Rate = 76.7200m, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new CurrencyRate { Id = 5, BaseCurrencyId = 3, TargetCurrencyId = 2, Rate = 1.1379m, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false },
                new CurrencyRate { Id = 6, BaseCurrencyId = 4, TargetCurrencyId = 6, Rate = 1.5648m, CreatedAt = DateTime.UtcNow, IsActive = true, IsDeleted = false }
            );
        }

        /*******************************************************************
            SaveChanges Enrichment
        ******************************************************************/
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                        .Select(e => e.Entity);

            foreach (var entity in entities)
            {
                if (entity is IValidateable validateableEntity)
                {
                    validateableEntity.Validate();
                }
            }

            return base.SaveChanges();
        }
    }
}