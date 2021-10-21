using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ServicesCommands.Data.Repositories;
using ServicesCommands.Dtos.Readonly;
using ServicesCommands.Models;

namespace ServicesCommands.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFsctory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory,IMapper mapper)
        {
            _scopeFsctory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventTpe = DetermineEvent(message);

            switch(eventTpe)
            {
                case EventType.PlatformPublished:
                AddPlatform(message);
                //TO DO
                break;


                default:
                break;
            }
        }
        
        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining event");
            var eventType = JsonSerializer.Deserialize<GenericEventDTO>(notificationMessage);

            switch(eventType.Event)
            {
                case "platform_Published":
                Console.WriteLine("--> Platform Published Event Detected");
                return EventType.PlatformPublished;
                default:
                System.Console.WriteLine("--> Could not determine event type");
                return EventType.Undetermined;
            }
        }

        private void AddPlatform(string platformPublishedMessage)
        {
            using(var scope = _scopeFsctory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                var platformPublishedDTO = JsonSerializer.Deserialize<PlatformPublishedDTO>(platformPublishedMessage);
                try
                {
                     var plat = _mapper.Map<Platform>(platformPublishedDTO);
                     if(!repo.ExternalPlatformExists(plat.ExternalID))
                     {
                         repo.CreatePlatform(plat);
                         repo.SaveChanges();
                         System.Console.WriteLine("--> Platform added");
                     }
                     else
                     {
                         System.Console.WriteLine("--> Platform already exists...");
                     }
                }
                catch (System.Exception ex)
                {
                    
                    System.Console.WriteLine($"--> COuld not add platform to DB {ex.Message}");
                }
            }
        }
    }
    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}