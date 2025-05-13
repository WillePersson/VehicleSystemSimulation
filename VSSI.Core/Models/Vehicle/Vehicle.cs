using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSSI.Core.Enums;
using VSSI.Core.Models.Vehicle;

namespace VSSI.Core.Models.Vehicle
{
    public class Vehicle
    {
        private readonly Random _rand = new();

        public double ThrottleInput { get; set; }
        public double EngineRpm { get; private set; }
        public double Speed { get; private set; }
        public double Temperature { get; private set; }

        // New fields
        public double BatteryVoltage { get; private set; } = 12.6;
        public double FuelLevel { get; private set; } = 100;
        public double OilPressure { get; private set; }
        public double CoolantTemperature { get; private set; }

        public void UpdateState()
        {
            EngineRpm = 800 + ThrottleInput * 50 + _rand.Next(-100, 100);
            Speed = ThrottleInput * 1.2 + _rand.NextDouble() * 2;
            Temperature += EngineRpm / 10000 + _rand.NextDouble();
            Temperature = Math.Clamp(Temperature, 20, 130);

            // Additional simulation logic
            BatteryVoltage = 12.6 + _rand.NextDouble() * 0.4 - 0.2;
            FuelLevel -= 0.05 + _rand.NextDouble() * 0.02;
            FuelLevel = Math.Max(0, FuelLevel);
            OilPressure = (EngineRpm > 1000) ? 2.0 + _rand.NextDouble() * 0.5 : 0.5 + _rand.NextDouble() * 0.5;
            CoolantTemperature = Temperature + _rand.NextDouble() * 2;

            Console.WriteLine($"RPM: {EngineRpm}, Speed: {Speed}, Fuel: {FuelLevel}");
        }

        public List<Signal> GetSignals()
        {
            return SignalRegistry.All.Select(def => new Signal
            {
                Id = def.Id,
                Name = def.Name,
                Unit = def.Unit,
                Value = def.ValueProvider(this),
                WarningThreshold = def.WarningThreshold,
                CriticalThreshold = def.CriticalThreshold,
                Timestamp = DateTime.Now,
                Type = def.Type
            }).ToList();
        }
    }
}
