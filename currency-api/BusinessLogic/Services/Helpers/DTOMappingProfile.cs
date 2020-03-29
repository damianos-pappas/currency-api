using System.Linq;
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

            CreateMap<User, UserDTO>()
            .ForMember(dto => dto.UserRoles, opt => opt.MapFrom(src => src.UserRoleRelations.Select(ur=> ur.Role.Description)));
            CreateMap<UserDTO, User>();
        }
    }
}