using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using SharpPcap;

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
        /// 根据当前的内网ipv4地址，来得到对应的mac地址
        /// </summary>
        /// <returns></returns>
        public static PhysicalAddress GetLocalMac()
        {
            var ip = GetLocalIP().ToString();
            var devices = CaptureDeviceList.Instance;
            foreach (var dev in devices)
            {
                if (dev.ToString().Contains(ip))
                {
                    dev.Open();
                    var result = dev.MacAddress;
                    dev.Close();
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据当前的内网ipv4地址，来得到对应的mac地址<br/>
        /// 原理是使用的是抓包工具<br/>
        /// ubuntu需要安装apt install libpcap-dev<br/>
        /// windows需要安装pcap<br/>
        /// 格式:AA-BB-CC-DD-EE-FF
        /// </summary>
        /// <returns></returns>
        public static string GetLocalMacString()
        {
            var physicalAddress = GetLocalMac();
            if (physicalAddress != null)
            {
                return String.Join("-", physicalAddress.GetAddressBytes().Select(x => x.ToString("X2")).ToArray());
            }
            return null;
        }

        /// <summary>
        /// 获取当前ipv4的子网掩码
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetNetMask()
        {
            var ip = GetLocalIP();
            var macAddress = GetLocalMac();
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var nwif in networkInterfaces)
            {
                if (nwif.GetPhysicalAddress().ToString() == macAddress.ToString())
                {
                    foreach (var item in nwif.GetIPProperties().UnicastAddresses)
                    {
                        if (item.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return item.IPv4Mask;
                        }
                    }
                }
            }
            return null;
        }
    }
}
