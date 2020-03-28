
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface ICurrencyService 
    {
        IEnumerable<CurrencyDTO> Get(int pageNumber, int pageSize, string sortTerm , bool sortDesc , string searchTerm);

        CurrencyDTO Get(long id);

        CurrencyDTO Add(CurrencyDTO entity);

        void Delete(long Id, bool safeDelete = false);

        CurrencyDTO Update(CurrencyDTO entity);

    }
}