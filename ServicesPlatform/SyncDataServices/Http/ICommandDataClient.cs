using System.Threading.Tasks;

namespace ServicesPlatform.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SeedPlatformToCommand();
    }
}