using System;
using System.Collections.Generic;
using currencyApi.Data;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public class CurrencyService : ICurrencyService 
    {
        ICurrenciesRepository _currenciesRepo;
        public CurrencyService(ICurrenciesRepository currenciesRepo){
            _currenciesRepo = currenciesRepo;
        }
        
        public IEnumerable<Currency> Get(){
            return _currenciesRepo.Get();
        }

        // public TDTO Get(){
        //     throw new NotImplementedException();
        // }

        // public TDTO Update(TDTO tDTO){
        //            throw new NotImplementedException();
        // }
        

    }
}