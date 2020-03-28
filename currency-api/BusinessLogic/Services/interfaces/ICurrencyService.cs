
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface ICurrencyService 
    {
         IEnumerable<Currency> Get();
   
    }
}