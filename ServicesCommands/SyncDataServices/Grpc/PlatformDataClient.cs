using System;
using System.Collections.Generic;
using AutoMapper;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ServicesCommands.Models;
using ServicesCommands.SyncDataServices.Grpc;
using ServicesPlatform;

namespace ServicesCommands.AsyncDataServices.Grpc
{
    public class PlatformDataClient : IPlatformDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PlatformDataClient(IConfiguration configuration,IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public IEnumerable<Platform> ReturnAllPlatforms()
        {
            Console.WriteLine($"--> Calling Grpc Service {_configuration["GrpcPlatform"]}");

            var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"]);
            var client = new GrpcPlatform.GrpcPlatformClient(channel);
            var request = new GetAllRequest();

            try
            {
                 var reply = client.GetAllPlatforms(request);

                 return _mapper.Map<IEnumerable<Platform>>(reply.Platform);
            }
            catch (System.Exception ex)
            {
                
                System.Console.WriteLine($"--> Could not call GrPc Server {ex.Message}");
                return null;
            }
        }
    }
}