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
        public CurrenciesController(ICurrencyService srv)
        {
            this._srv = srv;
        }

          [HttpGet]
        public IEnumerable<CurrencyDTO> Get([FromQuery]int pageNumber =0, int pageSize =0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            return _srv.Get( pageNumber,  pageSize,  sortTerm, sortDesc, searchTerm);
        }

        [HttpGet("{id}")]
        public CurrencyDTO Get(long id)
        {
            return  _srv.Get(id);
        }

        [HttpPost]
        public CurrencyDTO Add([FromBody] CurrencyDTO currencyDTO)
        {
            return _srv.Add(currencyDTO);
        }

        [HttpPut]
        public CurrencyDTO Update([FromBody] CurrencyDTO currencyDTO)
        {
            return _srv.Update(currencyDTO);
        }

        [HttpDelete("{id}")]
        public void Delete( long id)
        {
            _srv.Delete(id);
        }
    }
}
