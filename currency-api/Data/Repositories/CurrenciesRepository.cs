using System;
using System.Collections.Generic;
using System.Linq;
using currencyApi.Models;
using Microsoft.AspNetCore.Http;

namespace currencyApi.Data
{
    public class CurrenciesRepository : GenericRepository<Currency> ,ICurrenciesRepository
    {
        public CurrenciesRepository(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor)
        {

        }

        public PagedItems<Currency> Get(int pageNumber, int pageSize, string sortTerm , bool sortDesc, string searchTerm)
        {
            var result = GetAll();

            if(!String.IsNullOrWhiteSpace(searchTerm))
                result = result.Where(x=> x.Code.ToUpper().Contains(searchTerm.ToUpper()) 
                                            || x.Description.ToUpper().Contains(searchTerm.ToUpper()));

            if(pageNumber > 0 && pageSize > 0)
                result = result.Paginate(pageNumber ,pageSize);

            if(!String.IsNullOrWhiteSpace(sortTerm))
                result = result.OrderBy(sortTerm, sortDesc);
            
            return new PagedItems<Currency>{
                Items = result.AsEnumerable(), 
                PageNumber = pageNumber,
                TotalPages = result.Count()
            };
        }

         public Currency GetOne(long id)
        {
            var result = GetAll();
            
            result = result.Where(x => x.Id == id);

            return result.FirstOrDefault();
        }

    }
}