using System.Collections.Generic;

namespace currencyApi.Models
{
    public class BaseLookup :  IIdentifiable
    {
        public long Id  {get;set;}
        public string Description {get;set;}
    }
}
