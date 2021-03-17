using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace kentxxq.Utils.Tests
{
    public class NetTest
    {
        [Fact]
        public void TestGetLocalIPv4()
        {
            var iPAddress = Net.GetLocalIPv4();
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                Assert.False(iPAddress == IPAddress.Parse("127.0.0.1"));
            }
            else
            {
                Assert.True(iPAddress == IPAddress.Parse("127.0.0.1"));
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
    }
}