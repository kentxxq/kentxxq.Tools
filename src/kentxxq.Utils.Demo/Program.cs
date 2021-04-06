using System;
using System.Data;
using System.Linq;
using System.Net;

namespace kentxxq.Utils.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 打印局域网存活主机

            //var ips = Net.GetAliveIpListByICMP();
            //foreach (var ip in ips)
            //{
            //    Console.WriteLine(ip.ToString());
            //}

            #endregion 打印局域网存活主机

            #region 测试ping

            var pingResult = Connection.PingIp(IPAddress.Parse("8.8.8.8"));

            Console.WriteLine($"是否能连接:{pingResult}");

            #endregion 测试ping

            #region 发送rarp包

            //var piMacAddress = PhysicalAddress.Parse("F4-4C-70-40-3F-89");

            //var ip = Net.GetIpByPhysicalAddress(piMacAddress);

            //Console.WriteLine($"{ip}");

            #endregion 发送rarp包

            #region 获取当前网关和网关mac地址

            var gateway = Net.GetLocalGateway();
            Console.WriteLine($"网关地址:{gateway}");

            var gatewayMacAddress = Net.GetPhysicalAddressByIp(gateway);
            Console.WriteLine($"网关MAC地址:{gatewayMacAddress}");

            #endregion 获取当前网关和网关mac地址

            #region 获取172.18.76.202的mac地址

            var address = Net.GetPhysicalAddressByIp(IPAddress.Parse("172.18.76.202"));
            if (address != null)
            {
                Console.WriteLine($"172.18.76.202的mac地址:{string.Join("-", address.GetAddressBytes().Select(x => x.ToString("X2")))}");
            }
            else
            {
                Console.WriteLine("172.18.76.202获取失败");
            }

            #endregion 获取172.18.76.202的mac地址

            #region 获取当前子网掩码

            var netMask = Net.GetNetMask();
            if (netMask != null)
            {
                Console.WriteLine($"当前子网掩码:{netMask}");
            }

            //Console.WriteLine($"子网掩码:{Net.GetSubNetIpAddress()}");

            #endregion 获取当前子网掩码

            #region 测试mac地址

            var macAddressString = Net.GetLocalMacString();
            if (macAddressString != null)
            {
                Console.WriteLine($"当前网络连接正常(内网),mac地址为:{macAddressString}");
            }
            else
            {
                Console.WriteLine("当前无网络连接");
            }

            #endregion 测试mac地址

            #region 获取本机当前使用的ipv4地址

            var iPAddress = Net.GetLocalIP();
            Console.WriteLine($"本地ip地址为:{iPAddress}");

            #endregion 获取本机当前使用的ipv4地址

            #region 测试ldap连接

            var ldapResult = LDAP.VerifyLdapConnection("ldap.kentxxq.com", 389, @"cn=admin,dc=ldap,dc=kentxxq,dc=com", "123456");
            Console.WriteLine($"测试ldap.kentxxq.com的连接:{ldapResult}");

            #endregion 测试ldap连接
        }
    }
}
