using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using currencyApi.BusinessLogic.Services;
using currencyApi.Data;
using currencyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace currencyApi.Controllers
{
    [Authorize(Roles = "admin-currencies")]
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
        public PagedItems<CurrencyDTO> Get([FromQuery]int pageNumber =0, int pageSize =0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            var currencies = _srv.Get( pageNumber,  pageSize,  sortTerm, sortDesc, searchTerm);
            
            return  new PagedItems<CurrencyDTO> {
                Items = _srv.MapToDTO(currencies.Items),
                PageNumber = currencies.PageNumber,
                TotalPages = currencies.TotalPages
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CurrencyDTO> GetById(long id)
        {
            var currency = _srv.Get(id);

            if (currency == null)
                return NotFound("Currency not found");
            else
                return  Ok(_srv.MapToDTO(currency));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CurrencyDTO> Add([FromBody] CurrencyDTO currencyDTO)
        {
            var addedCurrency = _srv.Add(currencyDTO);

            _unitOfWork.Commit();

            return CreatedAtAction( nameof(GetById), new { id = addedCurrency.Id }, _srv.MapToDTO(addedCurrency));
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
