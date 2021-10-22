using System.Collections.Generic;
using ServicesCommands.Models;

namespace ServicesCommands.SyncDataServices.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}