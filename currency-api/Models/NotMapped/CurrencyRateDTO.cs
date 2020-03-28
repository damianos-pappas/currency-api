using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class CurrencyRateDTO
    {
        public long Id {get; set;}
        public long BaseCurrencyId {get; set;}
        public string BaseCurrencyCode {get;set;}
        public long TargetCurrencyId {get; set;}
        public string TargetCurrencyCode {get;set;}
        public decimal Rate {get;set;}

        public bool IsActive {get;set;}   
    }
}