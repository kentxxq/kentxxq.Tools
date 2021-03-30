using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace kentxxq.Utils
{
    public static class Net
    {
        /// <summary>
        /// 获取本机ipv4内网ip<br/>
        /// 如果网络不可用返回127.0.0.1<br/>
        /// 如果之前网络可用，可能会返回之前保留下来的ip地址
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

        /// <summary>
        /// 很丑陋的实现，后面可能会用sharppcap来实现
        /// 获取当前有网络的mac地址，否则为"AA-BB-CC-DD-EE-FF"<br/>
        /// 排除接口名Npcap/Hyper/Loop
        /// </summary>
        /// <returns></returns>
        public static string GetLocalMac()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var nwif in networkInterfaces)
            {
                if (nwif.OperationalStatus == OperationalStatus.Up && !nwif.Description.Contains("Npcap") && !nwif.Description.Contains("Hyper") && !nwif.Description.Contains("Loop") && !nwif.Description.Contains("Loop") && !nwif.Description.Contains("Loop") && !nwif.Description.Contains("lo"))
                {
                    var macAddress = nwif.GetPhysicalAddress().GetAddressBytes();
                    return string.Join("-", macAddress.Select(x => x.ToString("X2")));
                }
            }
            return "AA-BB-CC-DD-EE-FF";
        }
    }
}
