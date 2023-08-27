using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public interface IMetricsStorage
    {
        /// <summary>
        /// 存储请求信息
        /// </summary>
        /// <param name="requestInfo">请求信息</param>
        void SaveRequestInfo(RequestInfo requestInfo);
        /// <summary>
        /// 获取指定接口名在给定时间范围内的请求信息
        /// </summary>
        /// <param name="apiName">Api接口名</param>
        /// <param name="startTimeInMillis">开始时间</param>
        /// <param name="endTimeInMillis">结束时间</param>
        /// <returns></returns>
        List<RequestInfo> GetRequestInfos(string apiName, long startTimeInMillis, long endTimeInMillis);
        /// <summary>
        /// 获取所有接口在给定时间范围内的请求信息
        /// </summary>
        /// <param name="startTimeInMillis">开始时间</param>
        /// <param name="endTimeInMillis">结束时间</param>
        /// <returns></returns>
        Dictionary<string, List<RequestInfo>> GetRequestInfos(long startTimeInMillis, long endTimeInMillis);
    }
}
