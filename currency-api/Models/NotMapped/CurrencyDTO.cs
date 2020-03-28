using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class CurrencyDTO
    {
        public long Id {get; set;}
        public string Code {get;set;}
        public string Description {get;set;}
        public bool IsActive {get;set;}    
    }
}