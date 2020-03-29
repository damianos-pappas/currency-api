
namespace currencyApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public CurrenciesContext Context { get; }

        public UnitOfWork(CurrenciesContext context)
        {
            Context = context;
            Context.Database.EnsureCreated();
        }
        
        public void Commit()
        {
            Context.SaveChanges();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
