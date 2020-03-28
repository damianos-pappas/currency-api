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

        public IEnumerable<CurrencyRateDTO> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm)
        {
            return _currencyRatesRepo.Get(pageNumber, pageSize, sortTerm, sortDesc, searchTerm)
                                    .Select(x => _mapper.Map<CurrencyRateDTO>(x));

        }

        public CurrencyRateDTO Get(long id)
        {
            CurrencyRate currencyrate = _currencyRatesRepo.GetOne(id);

            if (currencyrate != null)
                return _mapper.Map<CurrencyRateDTO>(currencyrate);
           
            return null;
        }

        public decimal? GetByRateByCodes(string baseCode, string targetCode ){
            CurrencyRate currencyRate = _currencyRatesRepo.GetByCodes(baseCode, targetCode);

            if (currencyRate != null && currencyRate.IsActive)
                return currencyRate.Rate;
           
            return null;
        }
        
        public IEnumerable<CurrencyRateDTO> GetByBaseCode(string baseCode){
            return _currencyRatesRepo.GetByBaseCode(baseCode).Select(x => _mapper.Map<CurrencyRateDTO>(x));
        }

        public CurrencyRateDTO Add(CurrencyRateDTO currencyRateDTO)
        {
            CurrencyRate currencyRate = _mapper.Map<CurrencyRate>(currencyRateDTO);
            _currencyRatesRepo.Add(currencyRate);
            return _mapper.Map<CurrencyRateDTO>(currencyRate);
        }

        public void Delete(long Id, bool safeDelete = false)
        {
            _currencyRatesRepo.Delete(Id, safeDelete);
        }

        public CurrencyRateDTO Update(CurrencyRateDTO currencyRateDTO)
        {
            CurrencyRate currencyRate = _mapper.Map<CurrencyRate>(currencyRateDTO);
            _currencyRatesRepo.Update(currencyRate);
            return _mapper.Map<CurrencyRateDTO>(currencyRate);
        }

    }
}