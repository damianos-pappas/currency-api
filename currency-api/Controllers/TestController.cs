using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        CurrenciesContext _db;
        public TestController(CurrenciesContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IEnumerable<CurrencyRate> Get()
        {
            IEnumerable<CurrencyRate> res = _db.CurrencyRates.Include(r => r.BaseCurrency)
                                            .Include(r => r.TargetCurrency).ToList();


            return res;

        }
    }
}
