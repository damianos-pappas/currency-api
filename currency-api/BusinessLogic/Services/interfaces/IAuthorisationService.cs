
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface IAuthorisationService 
    {
        UserLoginDTO Login(UserLoginDTO userLoginDTO);

        bool UpdatePassword(UserLoginDTO userLoginDTO);

    }
}