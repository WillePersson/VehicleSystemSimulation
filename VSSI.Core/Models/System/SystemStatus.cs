using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSSI.Core.Enums;

namespace VSSI.Core.Models.System
{
    public class SystemStatus
    {
        public BootState BootState { get; set; } = BootState.Off;
        public bool EngineStarted { get; set; } = false;
        public string Message { get; set; } = "System is powered off.";
    }
}
