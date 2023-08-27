using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    public class CreditTransaction
    {
        /// <summary>
        /// 明细ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 赚取或消费渠道ID
        /// </summary>
        public string ChannelID { get; set; }
        /// <summary>
        /// 相关事件ID，比如订单ID、评论ID、优惠价换购交易ID
        /// </summary>
        public string EventID { get; set; }
        /// <summary>
        /// 积分（赚取为正值、消费为负值）
        /// </summary>
        public string Credit { get; set; }
        /// <summary>
        /// 积分赚钱或消费时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 积分过期时间
        /// </summary>
        public DateTime ExpiredTime { get; set; }
    }
}
