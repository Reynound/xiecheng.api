using AutoMapper;
using xiecheng.api.Dtos;
using xiecheng.api.Modles;

namespace xiecheng.api.Profiles;

public class TouristRoutesProfile : Profile
{
    public TouristRoutesProfile()
    {
        //默认映射名字相同的字段
        CreateMap<TouristRoute, TouristRouteDto>()
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1)))
            .ForMember(dest => dest.DepartureCity,
                opt => opt.MapFrom(src => src.DepartureCity.ToString()))
            .ForMember(dest => dest.TravelDays,
                opt => opt.MapFrom(src => src.TravelDays.ToString()))
            .ForMember(dest => dest.TripType,
                opt => opt.MapFrom(src => src.TripType.ToString()));
    }
}