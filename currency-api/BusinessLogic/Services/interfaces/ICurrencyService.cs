
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface ICurrencyService 
    {
        IEnumerable<Currency> Get(int pageNumber, int pageSize, string sortTerm , bool sortDesc , string searchTerm);

        Currency Get(long id);

        Currency Add(CurrencyDTO entity);

        void Delete(long Id, bool safeDelete = false);

        Currency Update(CurrencyDTO entity);

        IEnumerable<CurrencyDTO> MapToDTO(IEnumerable<Currency> currencies);
        CurrencyDTO MapToDTO(Currency currency);

    }
}