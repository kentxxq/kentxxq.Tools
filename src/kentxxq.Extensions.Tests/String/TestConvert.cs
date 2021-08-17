using kentxxq.Extensions.String;
using Xunit;

namespace kentxxq.Extensions.Tests.String
{
    public class TestConvert
    {
        [Fact]
        public void TestUrlToIPEndPoint()
        {
            var url = "kentxxq.com:443";
            var ipEndPoint = url.UrlToIPEndPoint();
            Assert.Equal("185.199.110.153:443", ipEndPoint.ToString());
        }
    }
}
