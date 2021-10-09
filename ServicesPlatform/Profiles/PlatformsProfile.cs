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
        }
       
    }
}