using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class Aggregator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestInfos"></param>
        /// <param name="durationInMillis"></param>
        /// <returns></returns>
        public static RequestStat Aggregate(List<RequestInfo> requestInfos, long durationInMillis)
        {
            double maxResponseTime = Double.MinValue;
            double minResponseTime = Double.MaxValue;
            double avgResponseTime = -1;
            double p999ResponseTime = -1;
            double p99ResponseTime = -1;
            double sumResponseTime = 0;
            long count = 0;
            foreach (RequestInfo requestInfo in requestInfos)
            {
                ++count;
                if (requestInfo.ResponseTime > maxResponseTime)
                {
                    maxResponseTime = requestInfo.ResponseTime;
                }

                if (requestInfo.ResponseTime < minResponseTime)
                {
                    minResponseTime = requestInfo.ResponseTime;
                }

                sumResponseTime += requestInfo.ResponseTime;
            }

            if (count > 0)
            {
                avgResponseTime = sumResponseTime / count;
            }

            long tps = count / durationInMillis * 1000;
            requestInfos.Sort((x, y) =>
            {
                if (x.ResponseTime > y.ResponseTime)
                {
                    return 1;
                }
                else if (x.ResponseTime < y.ResponseTime)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });

            int idx999 = (int)(count * 0.999);
            int idx99 = (int)(count * 0.99);
            if (count > 0)
            {
                p999ResponseTime = requestInfos[idx999].ResponseTime;
                p99ResponseTime = requestInfos[idx99].ResponseTime;
            }

            var requestStat = new RequestStat
            {
                MaxResponseTime = maxResponseTime,
                MinResponseTime = minResponseTime,
                AvgResponseTime = avgResponseTime,
                P999ResponseTime = p999ResponseTime,
                P99ResponseTime = p99ResponseTime,
                Count = count,
                TPS = tps,
            };
            return requestStat;
        }
    }
}
