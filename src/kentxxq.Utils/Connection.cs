using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace kentxxq.Utils
{
    public static class Connection
    {
        /// <summary>
        /// ping测试
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool PingIp(IPAddress ip)
        {
            var pingSender = new Ping();
            // 32字节数据
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var buffer = Encoding.ASCII.GetBytes(data);
            var timeout = 100;
            var pingOption = new PingOptions(64, true);
            var reply = pingSender.Send(ip, timeout, buffer, pingOption);
            return reply.Status == IPStatus.Success;
        }

        /// <summary>
        /// ping异步测试
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static async Task<bool> PingIpAsync(IPAddress ip)
        {
            var pingSender = new Ping();
            // 32字节数据
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var buffer = Encoding.ASCII.GetBytes(data);
            var timeout = 100;
            var pingOption = new PingOptions(64, true);
            var reply = await pingSender.SendPingAsync(ip, timeout, buffer, pingOption);
            return reply.Status == IPStatus.Success;
        }
    }
}
