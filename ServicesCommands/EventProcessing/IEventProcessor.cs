namespace ServicesCommands.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}