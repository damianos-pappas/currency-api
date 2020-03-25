using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class Currency : BaseModel
    {
        public string Code {get;set;}
        public string Description {get;set;}
         public ICollection<CurrencyRate> CurrencyRates  {get;set;}
    }
}