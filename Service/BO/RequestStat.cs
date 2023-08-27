using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class RequestStat
    {
        // 最大响应时间
        public double MaxResponseTime { get; set; }
        // 最小响应时间
        public double MinResponseTime { get; set; }
        // 平均响应时间
        public double AvgResponseTime { get; set; }
        public double P999ResponseTime { get; set; }
        public double P99ResponseTime { get; set; }
        public long Count { get; set; }
        public long TPS { get; set; }
    }
}
