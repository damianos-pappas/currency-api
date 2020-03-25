using System;
using System.Collections.Generic;
using currencyApi.Data;

namespace currencyApi.BusinessLogic.Services
{
    public class CurrencyService
    {
        ICurrenciesRepository _currenciesRepo;
        public CurrencyService(ICurrenciesRepository currenciesRepo){
            _currenciesRepo = currenciesRepo;
        }
        
        public IEnumerable<TDTO> GetAll(){
            throw new NotImplementedException();
        }

        public TDTO Get(){
            throw new NotImplementedException();
        }

        public TDTO Update(TDTO tDTO){
                   throw new NotImplementedException();
        }
        

    }
}