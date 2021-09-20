using System.Threading.Tasks;
using ServicesPlatform.DTOs.Readable;

namespace ServicesPlatform.SyncDataServices.HttpRun
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDTO platform);
    }
}