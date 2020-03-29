using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using currencyApi.BusinessLogic.Services;
using currencyApi.Data;
using currencyApi.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id:long}")]
        public ActionResult<CurrencyRateDTO> GetById(long id)
        {
            var currencyRate = _srv.Get(id);

            if (currencyRate == null)
                return NotFound("Currency Rate not found");
            else
                return Ok(_srv.MapToDTO(currencyRate));
        }

        [HttpGet("{baseCode}/{targetCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<decimal?> GetRateByCodes(string baseCode, string targetCode)
        {
            var result = _srv.GetRateByCodes(baseCode, targetCode);

            if (result == null)
                return NotFound("Currency Rate not found");
            else
                return Ok(result);
        }

        [HttpGet("calculate/{baseCode}/{targetCode}/{amount}")]
        public ActionResult<decimal?> CalculateByCodes(string baseCode, string targetCode, decimal amount)
        {
            var result = _srv.CalculateByCodes(baseCode, targetCode, amount);
            if (result == null)
                return NotFound("Currency Rate not found");
            else
                return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CurrencyRateDTO> Add([FromBody] CurrencyRateDTO currencyRateDTO)
        {
            if(_srv.GetByCurrencyIds(currencyRateDTO.BaseCurrencyId, currencyRateDTO.TargetCurrencyId)!=null)
                throw new ApplicationException("Currency Pair rate already exists"); 
                
            var addedCurrencyRate = _srv.Add(currencyRateDTO);

            _unitOfWork.Commit();

            return CreatedAtAction(nameof(GetById), new { id = addedCurrencyRate.Id }, _srv.MapToDTO(addedCurrencyRate));
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

            _unitOfWork.Commit();

        }
    }
}
