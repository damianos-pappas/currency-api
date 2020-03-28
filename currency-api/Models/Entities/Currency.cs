using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class Currency : BaseModel, IValidateable
    {
        public string Code {get;set;}
        public string Description {get;set;}
         public ICollection<CurrencyRate> CurrencyRates  {get;set;}

         public void Validate(){
             if(String.IsNullOrWhiteSpace(Code) || Code.Length!=3){
                 throw new ApplicationException("Code must have three characters");
             }
         }
    }
}