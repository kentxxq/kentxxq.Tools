using kentxxq.Extensions.String;
using Xunit;

namespace kentxxq.Extensions.Tests.String
{
    public class TestEncode
    {
        [Fact]
        public void TestSha256()
        {
            var text = "123456";
            Assert.Equal("8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", text.Sha256());
        }
    }
}