using currencyApi.Models;

namespace currencyApi.Data
{
    public class CurrencyRatesRepository : GenericRepository<CurrencyRate> , ICurrencyRatesRepository
    {
        public CurrencyRatesRepository(IUnitOfWork unitOfWork):base( unitOfWork)
        {
        }
    }
}