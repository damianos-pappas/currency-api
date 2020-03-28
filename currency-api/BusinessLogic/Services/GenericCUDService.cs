using System;
using AutoMapper;
using currencyApi.Data;

namespace currencyApi.BusinessLogic.Services
{
    public class GenericCUDService<T, TDTO> : IGenericCUDService< TDTO>   where T : class
                                                                            where TDTO : class
    {
        IGenericRepository<T> _Trepo;
        IMapper _Tmapper;

        public GenericCUDService(IMapper mapper, IGenericRepository<T> repo)
        {
            _Trepo = repo;
            _Tmapper = mapper;
        }

        public TDTO Add(TDTO dto)
        {
            T entity = _Tmapper.Map<T>(dto);
            _Trepo.Add(entity);
            return _Tmapper.Map<TDTO>(entity);
        }

        public void Delete(long Id, bool safeDelete = false)
        {
            _Trepo.Delete(Id,safeDelete);
        }
        
        public TDTO Update(TDTO dto)
        {
            T entity = _Tmapper.Map<T>(dto);
            _Trepo.Update(entity);
            return _Tmapper.Map<TDTO>(entity);
        }

    }
}