using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSSI.Core.Enums;

namespace VSSI.Core.Models.Vehicle
{
    public class SignalDefinition
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public double? WarningThreshold { get; set; }
        public double? CriticalThreshold { get; set; }
        public SignalType Type { get; set; }

        // How this signal calculates value from vehicle state
        public Func<Vehicle, double> ValueProvider { get; set; } = _ => 0;
    }
}
