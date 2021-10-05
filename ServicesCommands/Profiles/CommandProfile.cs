using AutoMapper;
using ServicesCommands.Dtos.Readonly;
using ServicesCommands.Dtos.WriteOnly;
using ServicesCommands.Models;

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

        }
    }
}