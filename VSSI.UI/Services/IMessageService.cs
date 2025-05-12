namespace VSSI.UI.Services
{
    public interface IMessageService
    {
        event Action<string> OnMessage;
        void Show(string message);
    }
}
