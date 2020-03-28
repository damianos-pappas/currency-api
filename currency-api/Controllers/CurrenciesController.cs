using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using currencyApi.BusinessLogic.Services;
using currencyApi.Data;
using currencyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace currencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        ICurrencyService _srv;
        IUnitOfWork _unitOfWork;
        public CurrenciesController(ICurrencyService srv, IUnitOfWork unitOfWork)
        {
            this._srv = srv;
            this._unitOfWork = unitOfWork;
        }

          [HttpGet]
        public IEnumerable<CurrencyDTO> Get([FromQuery]int pageNumber =0, int pageSize =0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            var currencies = _srv.Get( pageNumber,  pageSize,  sortTerm, sortDesc, searchTerm);
            
            return _srv.MapToDTO(currencies);
        }

        [HttpGet("{id}")]
        public CurrencyDTO Get(long id)
        {
            var currency = _srv.Get(id);

            return  _srv.MapToDTO(currency);
        }

        [HttpPost]
        public CurrencyDTO Add([FromBody] CurrencyDTO currencyDTO)
        {
            var addedCurrency = _srv.Add(currencyDTO);

            _unitOfWork.Commit();

            return _srv.MapToDTO(addedCurrency);
        }

        [HttpPut]
        public CurrencyDTO Update([FromBody] CurrencyDTO currencyDTO)
        {
            var updatedCurrency = _srv.Update(currencyDTO);

            _unitOfWork.Commit();

            return _srv.MapToDTO(updatedCurrency);
        }

        [HttpDelete("{id}")]
        public void Delete( long id)
        {
            _srv.Delete(id);

            _unitOfWork.Commit();

        }
    }
}
