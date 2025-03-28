namespace Kontenerowiec.Interfaces
{
    public interface IHazardNotifier
    {
        void NotifyHazard(string message, string containerNumber);
    }
}
