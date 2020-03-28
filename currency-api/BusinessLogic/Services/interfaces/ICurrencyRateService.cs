
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface ICurrencyRateService 
    {
        IEnumerable<CurrencyRateDTO> Get(int pageNumber, int pageSize , string sortTerm , bool sortDesc, string searchTerm);

        CurrencyRateDTO Get(long id);

        CurrencyRateDTO Add(CurrencyRateDTO entity);

        void Delete(long Id, bool safeDelete = false);

        CurrencyRateDTO Update(CurrencyRateDTO entity);

    }
}