
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.Data
{
    public interface ICurrenciesRepository : IGenericRepository<Currency>
    {
        IEnumerable<Currency> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm);

        Currency GetOne(long id);

    }
}