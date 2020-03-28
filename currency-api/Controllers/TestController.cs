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
    public class TestController : ControllerBase
    {
        ICurrencyRateService _srv;
        public TestController(ICurrencyRateService srv)
        {
            this._srv = srv;
        }

        [HttpGet]
        public IEnumerable<CurrencyRateDTO> Get()
        {
            return null;

        }

        [HttpPut]
        public void Update([FromBody] Currency currency)
        {

        }

        [HttpDelete("{id}")]
        public void Delete( long id)
        {

        }
    }
}
