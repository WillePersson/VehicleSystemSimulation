using VSSI.Core.Enums;
using VSSI.Core.Models.Vehicle;

namespace VSSI.UI.Services
{
    public class SimulationService : IDisposable
    {
        private readonly StartupManager _startupManager;
        private readonly Vehicle _vehicle = new();
        private readonly System.Timers.Timer _timer;
        private readonly object _lock = new();

        public event Action<List<Signal>>? SignalsUpdated;

        public SimulationService()
        {
            _timer = new System.Timers.Timer(500); // update every 500ms
            _timer.Elapsed += (s, e) => Update();
            // Do NOT start timer yet
        }
        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
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
                Console.WriteLine($"[SIM] Updating signals at {DateTime.Now} — Throttle: {_vehicle.ThrottleInput}");
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
                bool engineRunning = _startupManager?.CurrentStatus.EngineStarted == true;

                return _vehicle
                    .GetSignals()
                    .Where(s => engineRunning || s.Type != SignalType.EngineDependent)
                    .ToList();
            }
        }


        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
