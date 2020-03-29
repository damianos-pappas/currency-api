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
    public class CurrencyService : ICurrencyService
    {
        ICurrenciesRepository _currenciesRepo;
        IMapper _mapper;
        

        public CurrencyService(IMapper mapper, ICurrenciesRepository currenciesRepo)
        {
            _currenciesRepo = currenciesRepo;

            _mapper = mapper;
        }

        public IEnumerable<Currency> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm)
        {
            return _currenciesRepo.Get(pageNumber, pageSize, sortTerm, sortDesc, searchTerm)
            ;
        }

        public Currency Get(long id)
        {
            return _currenciesRepo.GetOne(id);
        }

        public Currency Add(CurrencyDTO currencyDTO)
        {
            Currency currency = _mapper.Map<Currency>(currencyDTO);
            _currenciesRepo.Add(currency);
            return currency;
        }

        public void Delete(long Id, bool safeDelete = false)
        {
            _currenciesRepo.Delete(Id, safeDelete);
        }

        public Currency Update(CurrencyDTO currencyDTO)
        {
            Currency currency = _mapper.Map<Currency>(currencyDTO);

            _currenciesRepo.Update(currency);
            return currency;
        }

        public IEnumerable<CurrencyDTO> MapToDTO(IEnumerable<Currency> currencies)
        {
            return currencies.Select(x => _mapper.Map<CurrencyDTO>(x));
        }

        public CurrencyDTO MapToDTO(Currency currency)
        {
            return _mapper.Map<CurrencyDTO>(currency);
        }
    }
}