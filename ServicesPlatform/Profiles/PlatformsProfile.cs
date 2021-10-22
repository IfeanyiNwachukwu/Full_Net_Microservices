using AutoMapper;
using ServicesPlatform.DTOs.Readable;
using ServicesPlatform.DTOs.Writable;
using ServicesPlatform.Models;

namespace ServicesPlatform.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
              // source -> Target
            CreateMap<Platform,PlatformReadDTO>();
            CreateMap<PlatformCreateDTOW,Platform>();
            CreateMap<PlatformReadDTO,PlatformPublishedDTO>();
            CreateMap<Platform, GrpcPlatformModel>()
            .ForMember(dest => dest.PlatformId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));
        }
       
    }
}