namespace VSSI.UI.Services
{
    public class MessageService : IMessageService
    {
        public event Action<string>? OnMessage;
        public void Show(string message)
        {
            OnMessage?.Invoke(message);
        }
    }
}
