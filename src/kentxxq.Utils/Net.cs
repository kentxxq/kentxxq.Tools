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
        public static IPAddress GetLocalIPv4()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var item in iPHostEntry.AddressList)
                {
                    if (item.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return item;
                    }
                }
            }
            return IPAddress.Loopback;
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
            switch (ip[0])
            {
                case 10:
                case 127:
                    return true;

                case 172:
                    return ip[1] >= 16 && ip[1] < 32;

                case 192:
                    return ip[1] == 168;

                default:
                    return false;
            }
        }
    }
}
