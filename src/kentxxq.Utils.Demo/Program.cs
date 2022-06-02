using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using kentxxq.Extensions.String;
using kentxxq.Utils;
using Assembly = System.Reflection.Assembly;

namespace kentxxq.Demo;

internal class Program
{
    private static void Main(string[] args)
    {
        #region 测试解析

        // var url = "kenxxq:443";
        // try
        // {
        //     var iPEndPoint = url.UrlToIPEndPoint();
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine($"解析失败:{e.Message}");
        // }

        #endregion

        #region 测试mysql连接

        // var result = Connection.TryConnectMysql("db4free.net", "kentxxq", "kentxxq_test_db", "kentxxq_test_db");
        // Console.WriteLine($"mysql连接结果:{result}");

        #endregion 测试mysql连接

        #region 打印局域网存活主机

        //var ips = Net.GetAliveIpListByICMP();
        //foreach (var ip in ips)
        //{
        //    Console.WriteLine(ip.ToString());
        //}

        #endregion 打印局域网存活主机

        #region 测试ping

        // todo: 需要继续深入了解异步...

        // var sw = Stopwatch.StartNew();

        //var tt = new List<Task<bool>>();
        //Task<bool> t = null;

        //for (int i = 0; i < 5; i++)
        //{
        //    //t = new Task<bool>(() => { return Connection.PingIp(IPAddress.Parse("114.114.114.113")); });
        //    tt.Add(Task.Run(() => { return Connection.PingIp(IPAddress.Parse("114.114.114.113")); }));
        //}

        //Task.WaitAll(tt.ToArray());

        //sw.Stop();
        //Console.WriteLine(sw.ElapsedMilliseconds);

        #endregion 测试ping

        #region 获取当前网关和网关mac地址

        // var gateway = Net.GetLocalGateway();
        // Console.WriteLine($"网关地址:{gateway}");
        //
        // if (gateway != null)
        // {
        //     var gatewayMacAddress = Net.GetPhysicalAddressByIp(gateway);
        //     Console.WriteLine($"网关MAC地址:{gatewayMacAddress}");
        // }

        #endregion 获取当前网关和网关mac地址

        #region 获取172.18.76.202的mac地址

        // var address = Net.GetPhysicalAddressByIp(IPAddress.Parse("172.18.76.202"));
        // if (address != null)
        // {
        //     Console.WriteLine(
        //         $"172.18.76.202的mac地址:{string.Join("-", address.GetAddressBytes().Select(x => x.ToString("X2")))}");
        // }
        // else
        // {
        //     Console.WriteLine("172.18.76.202获取失败");
        // }

        #endregion 获取172.18.76.202的mac地址

        #region 获取当前子网掩码

        // var netMask = Net.GetNetMask();
        // if (netMask != null)
        // {
        //     Console.WriteLine($"当前子网掩码:{netMask}");
        // }

        //Console.WriteLine($"子网掩码:{Net.GetSubNetIpAddress()}");

        #endregion 获取当前子网掩码

        #region 测试mac地址

        // var macAddressString = Net.GetLocalMacString();
        // if (macAddressString != null)
        // {
        //     Console.WriteLine($"当前网络连接正常(内网),mac地址为:{macAddressString}");
        // }
        // else
        // {
        //     Console.WriteLine("当前无网络连接");
        // }

        #endregion 测试mac地址

        #region 获取本机当前使用的ipv4地址

        // var iPAddress = Net.GetLocalIP();
        // Console.WriteLine($"本地ip地址为:{iPAddress}");

        #endregion 获取本机当前使用的ipv4地址

        #region 测试ldap连接

        // var ldapResult = LDAP.VerifyLdapConnection("ldap.kentxxq.com", 636, @"cn=admin,dc=ldap,dc=kentxxq,dc=com",
        //     "123456", true);
        // Console.WriteLine($"测试ldap.kentxxq.com的连接:{ldapResult}");

        #endregion 测试ldap连接

        #region 测试Aseembly

        var assemblyInformationalVersion = kentxxq.Utils.Assembly.GetAssemblyInformationalVersion()??"AssemblyInformationalVersion 无配置";
        var assemblyVersion = kentxxq.Utils.Assembly.GetAssemblyVersion()??"AssemblyVersion 无配置";
        var assemblyFileVersion = kentxxq.Utils.Assembly.GetAssemblyFileVersion()??"AssemblyFileVersion 无配置";
        var fullNugetVersion = kentxxq.Utils.Assembly.GetNugetFullVersion(typeof(kentxxq.Utils.Assembly))??"FullNugetVersion 无配置";
        var nugetVersion = kentxxq.Utils.Assembly.GetNugetVersion(typeof(kentxxq.Utils.Assembly))??"NugetVersion 无配置";
        Console.WriteLine(assemblyInformationalVersion);
        Console.WriteLine(assemblyVersion);
        Console.WriteLine(assemblyFileVersion);
        Console.WriteLine(fullNugetVersion);
        Console.WriteLine(nugetVersion);
        
        #endregion
        
    }
}
