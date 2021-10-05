using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesCommands.Data.Repositories;
using ServicesCommands.Dtos.Readonly;

namespace ServicesCommands.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private IMapper _mapper;

        public PlatformsController(ICommandRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from servicesCommand");
            var platformItems = _repository.GetAllPlatforms();
            var platformsToReturn = _mapper.Map<IEnumerable<PlatformDTO>>(platformItems);
            return Ok(platformsToReturn);
        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Inbound test Ok from Platforms Controller");
        }
    }
}