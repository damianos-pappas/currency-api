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
        IUnitOfWork _unitOfWork;
        public TestController(CurrenciesContext db)
        {
            this._db = db;
            this._unitOfWork = new UnitOfWork(db);
        }

        [HttpGet]
        public IEnumerable<Currency> Get()
        {
            // IEnumerable<CurrencyRate> res = _db.CurrencyRates.Include(r => r.BaseCurrency)
            //                                 .Include(r => r.TargetCurrency).ToList();

            CurrenciesRepository currenciesRepo = new CurrenciesRepository(_unitOfWork);
            var res = currenciesRepo.Get();
            return res;

        }

        
        [HttpPut]
        public void Update([FromBody] Currency currency)
        {
            // IEnumerable<CurrencyRate> res = _db.CurrencyRates.Include(r => r.BaseCurrency)
            //                                 .Include(r => r.TargetCurrency).ToList();

            CurrenciesRepository currenciesRepo = new CurrenciesRepository(_unitOfWork);
            currenciesRepo.Update(currency);
            _unitOfWork.Commit();
        }

        [HttpDelete("{id}")]
        public void Delete( long id)
        {
            // IEnumerable<CurrencyRate> res = _db.CurrencyRates.Include(r => r.BaseCurrency)
            //                                 .Include(r => r.TargetCurrency).ToList();

            CurrenciesRepository currenciesRepo = new CurrenciesRepository(_unitOfWork);
            //var currency = currenciesRepo.Get(id);

            
            currenciesRepo.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
