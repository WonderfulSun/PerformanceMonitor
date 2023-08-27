using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class RedisMetricsStorage : IMetricsStorage
    {
        public List<RequestInfo> GetRequestInfos(string apiName, long startTimeInMillis, long endTimeInMillis)
        {
            // ...
            throw new NotImplementedException();
        }

        public Dictionary<string, List<RequestInfo>> GetRequestInfos(long startTimeInMillis, long endTimeInMillis)
        {
            throw new NotImplementedException();
        }

        public void SaveRequestInfo(RequestInfo requestInfo)
        {
            throw new NotImplementedException();
        }
    }
}
