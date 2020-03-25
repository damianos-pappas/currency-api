using System;
using currencyApi.Data;

public interface IUnitOfWork : IDisposable
    {
        CurrenciesContext Context { get;  }
        void Commit();
    }