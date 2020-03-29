
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.Data
{
    public interface ICurrencyRatesRepository : IGenericRepository<CurrencyRate>
    {
        IEnumerable<CurrencyRate> Get(int pageNumber = 0, int pageSize = 0, string sortTerm = null, bool sortDesc = false, string searchTerm = null);

        CurrencyRate GetOne(long id);

        CurrencyRate GetByCodes(string baseCode, string targetCode);

        CurrencyRate GetByIds(long baseId, long targetId);

        IEnumerable<CurrencyRate> GetByBaseCode(string baseCode);

    }
}