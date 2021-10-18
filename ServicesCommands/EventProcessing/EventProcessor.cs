using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ServicesCommands.Dtos.Readonly;

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
            
        }
    }
    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}