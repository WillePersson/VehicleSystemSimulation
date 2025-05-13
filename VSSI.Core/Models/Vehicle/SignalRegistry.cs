using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSSI.Core.Enums;

namespace VSSI.Core.Models.Vehicle
{
    public static class SignalRegistry
    {
        public static readonly List<SignalDefinition> All = new()
    
        {
            new SignalDefinition
            {
                Id = "0x101",
                Name = "Engine RPM",
                Unit = "rpm",
                WarningThreshold = 4000,
                CriticalThreshold = 5500,
                Type = SignalType.EngineDependent,
                ValueProvider = v => v.EngineRpm
            },
            new SignalDefinition
            {
                Id = "0x102",
                Name = "Speed",
                Unit = "km/h",
                WarningThreshold = 80,
                CriticalThreshold = 100,
                Type = SignalType.EngineDependent,
                ValueProvider = v => v.Speed
            },
            new SignalDefinition
            {
                Id = "0x103",
                Name = "Engine Temp",
                Unit = "°C",
                WarningThreshold = 90,
                CriticalThreshold = 110,
                Type = SignalType.Diagnostic,
                ValueProvider = v => v.Temperature
            },
            new SignalDefinition
            {
                Id = "0x104",
                Name = "Battery Voltage",
                Unit = "V",
                WarningThreshold = 11.5,
                CriticalThreshold = 10.5,
                Type = SignalType.Diagnostic,
                ValueProvider = v => v.BatteryVoltage
            },
            new SignalDefinition
            {
                Id = "0x105",
                Name = "Fuel Level",
                Unit = "%",
                WarningThreshold = 20,
                CriticalThreshold = 10,
                Type = SignalType.EngineDependent,
                ValueProvider = v => v.FuelLevel
            },
            new SignalDefinition
            {
                Id = "0x106",
                Name = "Oil Pressure",
                Unit = "bar",
                WarningThreshold = 1.5,
                CriticalThreshold = 0.8,
                Type = SignalType.EngineDependent,
                ValueProvider = v => v.OilPressure
            },
            new SignalDefinition
            {
                Id = "0x107",
                Name = "Coolant Temp",
                Unit = "°C",
                WarningThreshold = 95,
                CriticalThreshold = 115,
                Type = SignalType.EngineDependent,
                ValueProvider = v => v.CoolantTemperature
            }
        };
    }
}
