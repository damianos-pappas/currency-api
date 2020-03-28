using AutoMapper;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
            
            CreateMap<CurrencyRate, CurrencyRateDTO>()
              .ForMember(dto => dto.BaseCurrencyCode, opt => opt.MapFrom(src => src.BaseCurrency.Code))
              .ForMember(dto => dto.TargetCurrencyCode, opt => opt.MapFrom(src => src.TargetCurrency.Code));
            CreateMap<CurrencyRateDTO, CurrencyRate>();

        }
    }
}