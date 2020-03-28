using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface IGenericCUDService<TDTO>
    {
        TDTO Add(TDTO entity);
        TDTO Update(TDTO entity);
        void Delete(long Id, bool safeDelete = false);

    }
}