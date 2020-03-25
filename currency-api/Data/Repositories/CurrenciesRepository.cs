using currencyApi.Models;

namespace currencyApi.Data
{
    public class CurrenciesRepository : GenericRepository<Currency> ,ICurrenciesRepository{
        public CurrenciesRepository(IUnitOfWork unitOfWork):base( unitOfWork)
        {
        }
    }
}