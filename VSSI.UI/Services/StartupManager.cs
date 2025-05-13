// StartupManager.cs
using VSSI.Core.Enums;
using VSSI.Core.Models.System;

namespace VSSI.UI.Services
{
    public class StartupManager
    {
        private readonly SystemStatus _status = new();

        public event Action<SystemStatus>? StatusChanged;

        public SystemStatus CurrentStatus => _status;

        public async Task StartSystemAsync(string code)
        {
            if (_status.BootState != BootState.Off || string.IsNullOrWhiteSpace(code))
                return;

            _status.BootState = BootState.Booting;
            _status.Message = "Booting system...";
            Notify();

            await Task.Delay(3000); // Simulate boot time

            if (code == "1234")
            {
                _status.BootState = BootState.Ready;
                _status.Message = "System ready. You may now start the engine.";
            }
            else
            {
                _status.BootState = BootState.Fault;
                _status.Message = "Error: Invalid startup code.";
            }

            Notify();
        }

        public void ShutdownSystem()
        {
            _status.BootState = BootState.Off;
            _status.EngineStarted = false;
            _status.Message = "System is powered off.";
            Notify();
        }

        public void StartEngine()
        {
            if (_status.BootState == BootState.Ready)
            {
                _status.EngineStarted = true;
                _status.Message = "Engine started.";
                Notify();
            }
        }

        private void Notify()
        {
            StatusChanged?.Invoke(_status);
        }
    }
}
