using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class RequestInfo
    {
        public string ApiName { get; set; }
        public double ResponseTime { get; set; }
        public long TimeStamp { get; set; }
    }
}
