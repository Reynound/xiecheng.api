using AutoMapper;
using xiecheng.api.Dtos;
using xiecheng.api.Modles;

namespace xiecheng.api.Profiles;

public class TouristRoutePicturesProfile : Profile
{
    public TouristRoutePicturesProfile()
    {
        CreateMap<TouristRoutePicture, TouristRoutePictureDto>()
            .ForMember(
                dest => dest.TouristRouteId,
                opt => opt.MapFrom(src => src.TouristRouteId)
            );
    }
}