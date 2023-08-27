using PerformanceMonitor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class UserController
    {
        #region 字段

        private Metrics metrics = new Metrics();

        #endregion

        #region 构造函数

        public UserController()
        {
            metrics.ExecutionCycle(new TimeSpan(0, 0, 2));
        }

        #endregion

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">用户注册信息</param>
        public void Register(UserVo user)
        {
            long startTimestamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            metrics.RecordTimestamp("register", startTimestamp);
            // 默认注册操作耗时...
            Random random = new Random();
            long responseTime = random.Next(11);
            //long responseTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startTimestamp;
            metrics.RecordResponseTime("register", responseTime);
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="telephone">电话</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public UserVo Login(string telephone, string password)
        {
            long startTimestamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            metrics.RecordTimestamp("login", startTimestamp);
            // 默认注册操作耗时...
            Random random = new Random();
            long responseTime = random.Next(11);
            //long responseTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startTimestamp;
            metrics.RecordResponseTime("login", responseTime);

            return new UserVo();
        }
    }
}
