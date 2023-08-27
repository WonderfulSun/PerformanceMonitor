using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IMetricsStorage storage = new RedisMetricsStorage();
                var consoleReporter = new ConsoleReporter(storage);
                consoleReporter.StartRepeatedReport(TimeSpan.FromSeconds(60), 60);

                MetricsCollector collector = new MetricsCollector(storage);
                collector.RecordRequest(new RequestInfo { ApiName = "register", ResponseTime = 123, TimeStamp = 10234 });
                collector.RecordRequest(new RequestInfo { ApiName = "register", ResponseTime = 223, TimeStamp = 11234 });
                collector.RecordRequest(new RequestInfo { ApiName = "register", ResponseTime = 323, TimeStamp = 12334 });
                collector.RecordRequest(new RequestInfo { ApiName = "login", ResponseTime = 23, TimeStamp = 12434 });
                collector.RecordRequest(new RequestInfo { ApiName = "login", ResponseTime = 1223, TimeStamp = 14234 });

                Thread.Sleep(100000);
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
