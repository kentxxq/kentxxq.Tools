using System;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Data;
using System.Linq;

namespace kentxxq.Utils.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 获取本机当前使用的ipv4地址

            var iPAddress = Net.GetLocalIP();
            Console.WriteLine($"本地ip地址为:{iPAddress}");

            #endregion 获取本机当前使用的ipv4地址

            #region 测试ldap连接

            var result = LDAP.VerifyLdapConnection("ldap.kentxxq.com", 636, @"cn=admin,dc=ldap,dc=kentxxq,dc=com", "123456");
            Console.WriteLine($"测试ldap.kentxxq.com的连接:{result}");

            #endregion 测试ldap连接
        }
    }
}
