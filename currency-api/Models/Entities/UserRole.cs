using System.Collections.Generic;

namespace currencyApi.Models
{
    public class UserRole : BaseLookup
    {
    }

    public enum UserRoleEnum 
    {
        USER_CURRENCIES_RATES = 1,

        ADMIN_CURRENCIES = 2,

        ADMIN_RATES = 3,

        ADMIN_USERS = 4,

    }
    
}