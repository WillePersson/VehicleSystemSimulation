using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSSI.Core.Models
{
    public class Vehicle
    {
        public double ThrottleInput { get; set; } // 0–100 %
        public double EngineRpm { get; private set; }
        public double Temperature { get; private set; }
        public double Speed { get; private set; }

        private readonly Random _rand = new();

        public List<Signal> GetSignals()
        {
            return new List<Signal>
            {
                new Signal { Id = "0x101", Name = "Engine RPM", Value = EngineRpm, Unit = "rpm", WarningThreshold = 4000, CriticalThreshold = 5500 },
                new Signal { Id = "0x102", Name = "Speed", Value = Speed, Unit = "km/h", WarningThreshold = 80, CriticalThreshold = 100 },
                new Signal { Id = "0x103", Name = "Engine Temp", Value = Temperature, Unit = "°C", WarningThreshold = 90, CriticalThreshold = 110 },
            };
        }

        public void UpdateState()
        {
            // Simple simulation logic
            EngineRpm = 800 + ThrottleInput * 50 + _rand.Next(-100, 100);
            Speed = ThrottleInput * 1.2 + _rand.NextDouble() * 2;
            Temperature += (EngineRpm / 10000) + _rand.NextDouble();
            Temperature = Math.Clamp(Temperature, 20, 130);
            Console.WriteLine($"RPM: {EngineRpm}, Speed: {Speed}");
        }
    }
}
