using ServicesPlatform.DTOs.Readable;
namespace  ServicesPlatform.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishedDTO model);
    }
}