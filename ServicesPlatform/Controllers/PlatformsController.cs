using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesPlatform.Contracts.RepoContracts;
using ServicesPlatform.DTOs.Readable;
using ServicesPlatform.DTOs.Writable;
using ServicesPlatform.Models;

namespace ServicesPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms....");
            var platformItems = _repository.GetAllPlatforms();
            var platformsToReturn = _mapper.Map<IEnumerable<PlatformReadDTO>>(platformItems);
            return Ok(platformsToReturn);
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if(platformItem != null)
            {
                var platformItemToReturn = _mapper.Map<PlatformReadDTO>(platformItem);
                return Ok(platformItemToReturn);

            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTOW model)
        {
            var platformModel = _mapper.Map<Platform>(model);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var PlatformToReturn = _mapper.Map<PlatformReadDTO>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = PlatformToReturn.Id}, PlatformToReturn);

        }


    }
}