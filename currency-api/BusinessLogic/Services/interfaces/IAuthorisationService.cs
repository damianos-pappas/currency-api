
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface IAuthorisationService 
    {
        UserLoginDTO Login(UserLoginDTO userLoginDTO);

        void UpdatePassword(UserLoginDTO userLoginDTO);
    }
}