using System.Collections.Generic;

namespace currencyApi.Models
{
    public class UserRole : BaseLookup
    {
    }

    public enum UserRoleEnum {
        CurrenciesAdmin = 1,
        RatesAdmin = 2
    }
    
}