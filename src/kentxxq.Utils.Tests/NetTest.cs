using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Xunit;

namespace kentxxq.Utils.Tests
{
    public class NetTest
    {
        [Fact]
        public void TestGetLocalIPv4()
        {
            var iPAddress = Net.GetLocalIP().ToString();
            if (iPAddress != "127.0.0.1")
            {
                var localIPs = Dns.GetHostAddresses(Dns.GetHostName()).Select(ip => ip.ToString());
                Assert.Contains(iPAddress, localIPs);
            }
        }

        [Fact]
        public void TestIsIsInternal()
        {
            var internalIP = new List<string>() { "::1/128", "127.0.0.1", "10.0.0.1", "172.16.5.1", "192.168.2.3" };
            var publicIP = "8.8.8.8";
            foreach (var ip in internalIP)
            {
                Assert.True(Net.IsInternal(ip));
            }
            Assert.False(Net.IsInternal(publicIP));
        }

        [Fact]
        public void TestGetLocalMac()
        {
            var macAddress = Net.GetLocalMac();
            if (macAddress != null)
            {
                var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                Assert.Contains(macAddress, networkInterfaces.Select(n => n.GetPhysicalAddress()));
            }
        }
    }
}
