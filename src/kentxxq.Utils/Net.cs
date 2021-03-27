using System;
using System.Net;
using System.Net.Sockets;

namespace kentxxq.Utils
{
    public static class Net
    {
        /// <summary>
        /// 获取本机ipv4内网ip，如果网络不可用返回127.0.0.1
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetLocalIP()
        {
            try
            {
                using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
                socket.Connect("223.5.5.5", 53);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
            catch (Exception)
            {
                return IPAddress.Loopback;
            }
        }

        /// <summary>
        /// 判断是否内网ip
        /// </summary>
        /// <param name="testIp"></param>
        /// <returns></returns>
        public static bool IsInternal(string testIp)
        {
            if (testIp.StartsWith("::1")) return true;

            byte[] ip = IPAddress.Parse(testIp).GetAddressBytes();
            return ip[0] switch
            {
                10 or 127 => true,
                172 => ip[1] >= 16 && ip[1] < 32,
                192 => ip[1] == 168,
                _ => false,
            };
        }
    }
}
