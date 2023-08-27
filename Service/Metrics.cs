using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceMonitor.Service
{
    /// <summary>
    /// 统计接口请求数据
    /// </summary>
    public class Metrics
    {
        #region 字段

        private Dictionary<string, List<double>> responseTimesDict = new Dictionary<string, List<double>>();
        private Dictionary<string, List<double>> timestampsDict = new Dictionary<string, List<double>>();
        private Timer executorTimer;
        #endregion

        #region 构造函数

        public Metrics()
        {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置定时器定时调用方法
        /// </summary>
        /// <param name="timeSpan"></param>
        public void ExecutionCycle(TimeSpan timeSpan)
        {
            TimerCallback callback = new TimerCallback(DoSomething);
            //executorTimer = new Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            executorTimer = new Timer(callback, null, TimeSpan.Zero, timeSpan);
        }

        /// <summary>
        /// 记录接口请求的响应时间
        /// </summary>
        /// <param name="apiName">请求接口名</param>
        /// <param name="responseTime">响应时间</param>
        public void RecordResponseTime(string apiName, double responseTime)
        {
            if (responseTimesDict.ContainsKey(apiName))
            {
                responseTimesDict[apiName].Add(responseTime);
            }
            else
            {
                responseTimesDict.Add(apiName, new List<double>() { responseTime });
            }
        }

        /// <summary>
        /// 记录接口请求的访问时间
        /// </summary>
        /// <param name="apiName">请求接口名</param>
        /// <param name="timestamp">访问时间戳</param>
        public void RecordTimestamp(string apiName, double timestamp)
        {
            if (timestampsDict.ContainsKey(apiName))
            {
                timestampsDict[apiName].Add(timestamp);
            }
            else
            {
                timestampsDict.Add(apiName, new List<double>() { timestamp });
            }
        }

        /// <summary>
        /// 计算接口请求的最大值、平均值和请求次数
        /// </summary>
        public void StartRepeatedReport()
        {
            var stats = new Dictionary<string, Dictionary<string, double>>();
            foreach (var item in responseTimesDict)
            {
                var apiName = item.Key;
                var apiResponseTime = item.Value;
                if (stats.ContainsKey(apiName))
                {
                    // 目前这段逻辑不会执行
                    // 计算每个Api接口请求响应时间的最大值 & 平均值
                    stats[apiName].Add("max", Max(apiResponseTime));
                    stats[apiName].Add("avg", Max(apiResponseTime));
                }
                else
                {
                    // 计算每个Api接口请求响应时间的最大值 & 平均值
                    stats.Add(apiName, new Dictionary<string, double>() { { "max", Max(apiResponseTime) } });
                    stats.Add(apiName, new Dictionary<string, double>() { { "avg", Max(apiResponseTime) } });
                }
            }

            foreach (var item in timestampsDict)
            {
                var apiName = item.Key;
                var apiTimestamps = item.Value;
                if (stats.ContainsKey(apiName))
                {
                    // 计算每个Api接口请求的总次数
                    stats[apiName].Add("count", apiTimestamps.Count);
                }
                else
                {
                    // 计算每个Api接口请求的总次数
                    stats.Add(apiName, new Dictionary<string, double>() { { "count", apiTimestamps.Count } });
                }
            }

            // 数据输出到控制台显示
            Console.WriteLine(JsonConvert.SerializeObject(stats));
        }

        #endregion

        #region 私有方法

        private void DoSomething(object state)
        {
            StartRepeatedReport();
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private double Max(List<double> dataSet)
        {
            // ...
            return dataSet.Max();
        }

        /// <summary>
        /// 获取平均值
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private double Avg(List<double> dataSet)
        {
            // ...
            return dataSet.Average();
        }

        #endregion
    }
}
