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
    public class CurrencyRatesController : ControllerBase
    {
        ICurrencyRateService _srv;
        IUnitOfWork _unitOfWork;
        public CurrencyRatesController(ICurrencyRateService srv, IUnitOfWork unitOfWork)
        {
            this._srv = srv;
            
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<CurrencyRateDTO> Get([FromQuery]int pageNumber = 0, int pageSize = 0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            var currencyRates = _srv.Get(pageNumber, pageSize, sortTerm, sortDesc, searchTerm);

            return _srv.MapToDTO(currencyRates);
        }

        [HttpGet("{id}")]
        public CurrencyRateDTO Get(long id)
        {
            var currencyRate = _srv.Get(id);

            return _srv.MapToDTO(currencyRate);
        }

        [HttpPost]
        public CurrencyRateDTO Add([FromBody] CurrencyRateDTO currencyRateDTO)
        {
            var addedCurrencyRate = _srv.Add(currencyRateDTO);

            _unitOfWork.Commit();

            return _srv.MapToDTO(addedCurrencyRate);
        }

        [HttpPut]
        public CurrencyRateDTO Update([FromBody] CurrencyRateDTO currencyRateDTO)
        {
            var updatedCurrencyRate = _srv.Update(currencyRateDTO);

            _unitOfWork.Commit();

            return _srv.MapToDTO(updatedCurrencyRate);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _srv.Delete(id);
        }
    }
}
