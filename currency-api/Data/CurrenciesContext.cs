using System;
using currencyApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

namespace currencyApi.Data
{
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext(DbContextOptions<CurrenciesContext> options)
            : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

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
                }
            );

            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Code = "EUR", Description = "Euro", CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false },
                new Currency { Id = 2, Code = "USD", Description = "US Dollar", CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  },
                new Currency { Id = 3, Code = "CHF", Description = "Swiss Franc", CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  },
                new Currency { Id = 4, Code = "GBP", Description = "British Pound", CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  },
                new Currency { Id = 5, Code = "JPY", Description = "Japan Yen", CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  },
                new Currency { Id = 6, Code = "CAD", Description = "Canadian Dollar", CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  }
            );

            modelBuilder.Entity<CurrencyRate>().HasData(
                new CurrencyRate { Id=1, BaseCurrencyId = 1, TargetCurrencyId = 2, Rate = 1.3764m, CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false },
                new CurrencyRate { Id=2, BaseCurrencyId = 1, TargetCurrencyId = 3, Rate = 1.2079m, CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false },
                new CurrencyRate { Id=3, BaseCurrencyId = 1, TargetCurrencyId = 4, Rate = 0.8731m, CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false },
                new CurrencyRate { Id=4, BaseCurrencyId = 2, TargetCurrencyId = 5, Rate = 76.7200m, CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  },
                new CurrencyRate { Id=5, BaseCurrencyId = 3, TargetCurrencyId = 2, Rate = 1.1379m, CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  },
                new CurrencyRate { Id=6, BaseCurrencyId = 4, TargetCurrencyId = 6, Rate = 1.5648m, CreatedAt= DateTime.UtcNow, IsActive=true, IsDeleted=false  }
            );
        }






    }
}