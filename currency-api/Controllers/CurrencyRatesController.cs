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
        public CurrencyRatesController(ICurrencyRateService srv)
        {
            this._srv = srv;
        }

        [HttpGet]
        public IEnumerable<CurrencyRateDTO> Get([FromQuery]int pageNumber =0, int pageSize =0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            return _srv.Get( pageNumber,  pageSize,  sortTerm, sortDesc, searchTerm);
        }

        [HttpGet("{id}")]
        public CurrencyRateDTO Get(long id)
        {
            return  _srv.Get(id);
        }

        [HttpPost]
        public CurrencyRateDTO Add([FromBody] CurrencyRateDTO currencyRateDTO)
        {
            return _srv.Add(currencyRateDTO);
        }

        [HttpPut]
        public CurrencyRateDTO Update([FromBody] CurrencyRateDTO currencyRateDTO)
        {
            return _srv.Update(currencyRateDTO);
        }

        [HttpDelete("{id}")]
        public void Delete( long id)
        {
            _srv.Delete(id);
        }
    }
}
