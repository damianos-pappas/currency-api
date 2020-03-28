using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using currencyApi.Data;
using currencyApi.Models;

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

        public IEnumerable<CurrencyDTO> Get( int pageNumber, int pageSize, string sortTerm , bool sortDesc, string searchTerm)
        {
            return _currenciesRepo.Get( pageNumber, pageSize,  sortTerm, sortDesc,  searchTerm)
            .Select(x => _mapper.Map<CurrencyDTO>(x));
        }

        public CurrencyDTO Get(long id)
        {
            Currency currency = _currenciesRepo.GetOne(id);

            if (currency != null)
                return _mapper.Map<CurrencyDTO>(currency);
           
            return null;
        }

        public CurrencyDTO Add(CurrencyDTO currencyDTO)
        {
            Currency currency = _mapper.Map<Currency>(currencyDTO);
            _currenciesRepo.Add(currency);
            return _mapper.Map<CurrencyDTO>(currency);
        }

        public void Delete(long Id, bool safeDelete = false)
        {
            _currenciesRepo.Delete(Id, safeDelete);
        }
        
        public CurrencyDTO Update(CurrencyDTO currencyDTO)
        {
             Currency currency = _mapper.Map<Currency>(currencyDTO);
            _currenciesRepo.Update(currency);
            return _mapper.Map<CurrencyDTO>(currency);
        }

    }
}