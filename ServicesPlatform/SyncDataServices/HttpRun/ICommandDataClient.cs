using System.Threading.Tasks;

namespace ServicesPlatform.SyncDataServices.HttpRun
{
    public interface ICommandDataClient
    {
        Task SeedPlatformToCommand();
    }
}