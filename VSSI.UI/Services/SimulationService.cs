using VSSI.Core.Models;

namespace VSSI.UI.Services
{
    public class SimulationService : IDisposable
    {
        private readonly Vehicle _vehicle = new();
        private readonly System.Timers.Timer _timer;
        private readonly object _lock = new();

        public event Action<List<Signal>>? SignalsUpdated;

        public SimulationService()
        {
            _timer = new System.Timers.Timer(500); // update every 500ms
            _timer.Elapsed += (s, e) => Update();
            _timer.Start();
        }

        private void Update()
        {
            lock (_lock)
            {
                _vehicle.UpdateState();
                var signals = _vehicle.GetSignals();
                SignalsUpdated?.Invoke(signals.Select(s => new Signal
                {
                    Id = s.Id,
                    Name = s.Name,
                    Unit = s.Unit,
                    Value = s.Value,
                    WarningThreshold = s.WarningThreshold,
                    CriticalThreshold = s.CriticalThreshold,
                    Timestamp = DateTime.Now
                }).ToList());
            }
        }

        public void SetThrottle(double value)
        {
            lock (_lock)
            {
                _vehicle.ThrottleInput = value;
            }
        }

        public List<Signal> GetLatestSignals()
        {
            lock (_lock)
            {
                return _vehicle.GetSignals();
            }
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
