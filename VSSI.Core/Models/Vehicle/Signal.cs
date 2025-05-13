using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSSI.Core.Enums;

namespace VSSI.Core.Models.Vehicle
{
    public class Signal
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public double Value { get; set; }
        public double? WarningThreshold { get; set; }
        public double? CriticalThreshold { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public SignalType Type { get; set; }

        public string Status =>
            CriticalThreshold.HasValue && Value >= CriticalThreshold ? "Critical" :
            WarningThreshold.HasValue && Value >= WarningThreshold ? "Warning" :
            "Normal";
    }

}
