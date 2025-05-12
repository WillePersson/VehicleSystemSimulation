using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSSI.Core.Models
{
    public class Signal
    {
        public string Id { get; set; } = string.Empty; // e.g., 0x101
        public string Name { get; set; } = string.Empty; // e.g., "Engine RPM"
        public string Unit { get; set; } = string.Empty; // e.g., "rpm"
        public double Value { get; set; }
        public double? WarningThreshold { get; set; } // optional: show warning above this
        public double? CriticalThreshold { get; set; } // optional: show error above this
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Status =>
            CriticalThreshold.HasValue && Value >= CriticalThreshold ? "Critical" :
            WarningThreshold.HasValue && Value >= WarningThreshold ? "Warning" :
            "Normal";
    }
}
