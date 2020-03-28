using System;
using System.Collections.Generic;
using System.Linq;
using currencyApi.Models;

namespace currencyApi.Data
{
    public class CurrenciesRepository : GenericRepository<Currency> ,ICurrenciesRepository
    {
        public CurrenciesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Currency> Get(int pageNumber, int pageSize, string sortTerm , bool sortDesc, string searchTerm)
        {
            var result = GetAll();

            if(!String.IsNullOrWhiteSpace(searchTerm))
                result = result.Where(x=> x.Code.ToUpper().Contains(searchTerm.ToUpper()) 
                                            || x.Description.ToUpper().Contains(searchTerm.ToUpper()));

            if(pageNumber > 0 && pageSize > 0)
                result = result.Paginate(pageNumber ,pageSize);

            if(!String.IsNullOrWhiteSpace(sortTerm))
                result = result.OrderBy(sortTerm, sortDesc);
            
            return result.AsEnumerable();
        }

         public Currency GetOne(long id)
        {
            var result = GetAll();
            
            result = result.Where(x => x.Id == id);

            return result.FirstOrDefault();
        }

    }
}