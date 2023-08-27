using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class MetricsCollector
    {
        // 基于接口而非实现编程
        private IMetricsStorage _IMetricsStorage;

        #region 构造函数
        // 依赖注入
        public MetricsCollector(IMetricsStorage metricsStorage)
        {
            _IMetricsStorage = metricsStorage;
        }
        #endregion

        #region 公共函数
        public void RecordRequest(RequestInfo requestInfo)
        {
            if (requestInfo == null || string.IsNullOrEmpty(requestInfo.ApiName))
            {
                return;
            }

            _IMetricsStorage.SaveRequestInfo(requestInfo);
        }
        #endregion
    }
}
