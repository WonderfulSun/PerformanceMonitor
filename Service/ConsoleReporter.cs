using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class ConsoleReporter
    {
        private IMetricsStorage _IMetricsStorage;
        private Timer executorTimer;

        public ConsoleReporter(IMetricsStorage metricsStorage)
        {
            _IMetricsStorage = metricsStorage;
        }

        /// <summary>
        /// 设置定时器定时调用方法
        /// </summary>
        /// <param name="timeSpan"></param>
        public void StartRepeatedReport(TimeSpan timeSpan, long durationInSeconds)
        {
            if (executorTimer == null)
            {
                TimerCallback callback = state =>
                {
                    // 在回调函数内使用闭包变量
                    Run(durationInSeconds);
                };
                //TimerCallback callback = new TimerCallback(Run);
                executorTimer = new Timer(callback, null, TimeSpan.Zero, timeSpan);
            }
            else
            {
                executorTimer.Change(TimeSpan.Zero, timeSpan);
            }
        }

        private void Run(object state)
        {
            // 第1个代码逻辑：根据给定的时间区间，从数据库中拉取数据；
            long durationInMillis = (long)state * 1000; // Todo: 10 替换成上层调用传入的参数
            long endTimeInMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long startTimeInMillis = endTimeInMillis - durationInMillis;
            var requestInfos = _IMetricsStorage.GetRequestInfos(startTimeInMillis, endTimeInMillis);
            var stats = new Dictionary<string, RequestStat>();
            foreach (var requestInfo in requestInfos)
            {
                string apiName = requestInfo.Key;
                var requestInfosPerApi = requestInfo.Value;
                // 第2个代码逻辑：根据原始数据，计算得到统计数据
                var requestStat = Aggregator.Aggregate(requestInfosPerApi, durationInMillis);
                stats.Add(apiName, requestStat);
            }

            // 第3个代码逻辑：将统计数据显示到终端（命令行或邮件等）；
            Console.WriteLine($"Time Span:[{startTimeInMillis}, {endTimeInMillis}]");
            Console.WriteLine(JsonConvert.SerializeObject(stats));
        }
    }
}
