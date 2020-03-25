using currencyApi.Models;

namespace currencyApi.Data
{
    public class CurrencyRatesRepository : GenericRepository<CurrencyRate>{
        public CurrencyRatesRepository(IUnitOfWork unitOfWork):base( unitOfWork)
        {
        }
    }
}