using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using currencyApi.Data;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        ICurrencyRatesRepository _currencyRatesRepo;
        IMapper _mapper;

        public CurrencyRateService(IMapper mapper, ICurrencyRatesRepository currencyRatesRepo)
        {
            _currencyRatesRepo = currencyRatesRepo;
            _mapper = mapper;
        }

        public IEnumerable<CurrencyRate> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm)
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