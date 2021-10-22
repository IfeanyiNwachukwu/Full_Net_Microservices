using AutoMapper;
using ServicesCommands.Dtos.Readonly;
using ServicesCommands.Dtos.WriteOnly;
using ServicesCommands.Models;
using ServicesPlatform;

namespace ServicesCommands.Profiles
{
    public class CommandProfile:Profile
    {
        public CommandProfile()
        {
            // Source -> Target
            CreateMap<Platform,PlatformDTO>();
            CreateMap<CommandDTOW,Command>();
            CreateMap<Command,CommandDTO>();
            CreateMap<PlatformPublishedDTO,Platform>()
            .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));

            CreateMap<GrpcPlatformModel,Platform>()
            .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.PlatformId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Commands, opt => opt.Ignore());
            

        }
    }
}