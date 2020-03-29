using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using currencyApi.Data;
using currencyApi.Helpers;
using currencyApi.Models;
using Microsoft.Extensions.Options;

namespace currencyApi.BusinessLogic.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        ICurrencyRatesRepository _currencyRatesRepo;
        IMapper _mapper;
        bool _updateReverseRate = false;

        public CurrencyRateService(IMapper mapper, ICurrencyRatesRepository currencyRatesRepo, IOptions<AppSettings> appSettingsOptions)
        {
            _currencyRatesRepo = currencyRatesRepo;
            _mapper = mapper;

            AppSettings appSettings = appSettingsOptions.Value;
            _updateReverseRate = appSettings.getUpdateReverseRateSetting();
        }

        public PagedItems<CurrencyRate> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm)
        {
            return _currencyRatesRepo.Get(pageNumber, pageSize, sortTerm, sortDesc, searchTerm);
        }

        public CurrencyRate Get(long id)
        {
            return _currencyRatesRepo.GetOne(id);
        }

        public decimal? GetRateByCodes(string baseCode, string targetCode)
        {
            CurrencyRate currencyRate = _currencyRatesRepo.GetByCodes(baseCode, targetCode);

            if (currencyRate != null && currencyRate.IsActive)
                return currencyRate.Rate;

            return null;
        }

        public CurrencyRate GetByCurrencyIds(long baseId, long targetId)
        {
            return _currencyRatesRepo.GetByIds(baseId, targetId);
        }

        public decimal? CalculateByCodes(string baseCode, string targetCode, decimal amount)
        {
            var rate = this.GetRateByCodes(baseCode, targetCode);

            return amount * rate;
        }

        public IEnumerable<CurrencyRate> GetByBaseCode(string baseCode)
        {
            return _currencyRatesRepo.GetByBaseCode(baseCode);
        }

        public CurrencyRate Add(CurrencyRateDTO currencyRateDTO)
        {
            CurrencyRate currencyRate = _mapper.Map<CurrencyRate>(currencyRateDTO);
            _currencyRatesRepo.Add(currencyRate);
            return currencyRate;
        }

        public void Delete(long Id, bool safeDelete = false)
        {
            _currencyRatesRepo.Delete(Id, safeDelete);
        }

        public CurrencyRate Update(CurrencyRateDTO currencyRateDTO)
        {
            CurrencyRate currencyRate = _mapper.Map<CurrencyRate>(currencyRateDTO);
            _currencyRatesRepo.Update(currencyRate);
            
            //Update the reverse currency pair rate depending on the setting
            if( _updateReverseRate){
                CurrencyRate oppositeCurrencyRate = _currencyRatesRepo.GetByIds(currencyRate.TargetCurrencyId, currencyRate.BaseCurrencyId);
                if( oppositeCurrencyRate != null && currencyRate.Rate != 0)
                    oppositeCurrencyRate.Rate = 1/currencyRate.Rate;
            }
            return currencyRate;
        }

        public IEnumerable<CurrencyRateDTO> MapToDTO(IEnumerable<CurrencyRate> currencyRates)
        {
            return currencyRates.Select(x => _mapper.Map<CurrencyRateDTO>(x));
        }

        public CurrencyRateDTO MapToDTO(CurrencyRate currencyRate)
        {
            return _mapper.Map<CurrencyRateDTO>(currencyRate);
        }
    }
}