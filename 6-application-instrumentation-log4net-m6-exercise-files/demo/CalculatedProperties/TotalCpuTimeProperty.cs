using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EventContext
{
    class TotalCpuTimeProperty
    {
        public override string ToString()
        {
            return Process.GetCurrentProcess().TotalProcessorTime.ToString();
        }
    }
}
