
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface ICurrencyRateService
    {
        PagedItems<CurrencyRate> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm);

        CurrencyRate Get(long id);

        decimal? GetRateByCodes(string baseCode, string targetCode);

        decimal? CalculateByCodes(string baseCode, string targetCode, decimal amount);

        CurrencyRate GetByCurrencyIds(long baseId, long targetId);

        IEnumerable<CurrencyRate> GetByBaseCode(string baseCode);

        CurrencyRate Add(CurrencyRateDTO entity);

        void Delete(long Id, bool safeDelete = false);

        CurrencyRate Update(CurrencyRateDTO entity);

        IEnumerable<CurrencyRateDTO> MapToDTO(IEnumerable<CurrencyRate> currencyRates);

        CurrencyRateDTO MapToDTO(CurrencyRate currencyRate);

    }
}