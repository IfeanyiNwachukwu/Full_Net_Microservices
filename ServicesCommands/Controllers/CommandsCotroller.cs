using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesCommands.Data.Repositories;
using ServicesCommands.Dtos.Readonly;
using ServicesCommands.Dtos.WriteOnly;

namespace ServicesCommands.Controllers
{
    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandDTO>> GetCommandsForPlatform(int platformId)
        {
            System.Console.WriteLine($"--> Hit GetCommandsForPlaform: {platformId}");
            if(!_repository.PlatformExists(platformId))
            {
                return NotFound();
            }
            var commands = _repository.GetCommandsForPlatform(platformId);
            var commandsToReturn = _mapper.Map<IEnumerable<CommandDTO>>(commands);
            return Ok(commandsToReturn);
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandDTO> GetCommandForPlatform(int platformId, int commandId)
        {
             System.Console.WriteLine($"--> GetCommandForPlatform: {platformId} / {commandId}");
            if(!_repository.PlatformExists(platformId))
            {
                return NotFound();
            }
            var command = _repository.GetCommand(platformId,commandId);
            if(command == null)
            {
                return NotFound();
            }
            var commandTOReturn = _mapper.Map<CommandDTO>(command);
            return Ok(commandTOReturn);

        }

        // [HttpPost]
        // public ActionResult<CommandDTO> CreateCommandForPlatform(int platformID,CommandDTOW model)
        // {
            
        // }
    }
}