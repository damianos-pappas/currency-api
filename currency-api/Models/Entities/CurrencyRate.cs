using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class CurrencyRate : BaseModel
    {
        public long BaseCurrencyId {get; set;}
        public Currency BaseCurrency {get;set;}
        public long TargetCurrencyId {get; set;}
        public Currency TargetCurrency {get;set;}
        public decimal Rate {get;set;}
    }
}