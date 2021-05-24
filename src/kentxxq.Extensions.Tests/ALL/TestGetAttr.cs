using System.ComponentModel;
using kentxxq.Extensions.ALL;
using Xunit;

namespace kentxxq.Extensions.Tests.ALL
{
    [Description("展示类")]
    public class Demo
    {
        [Description("主键id")]
        public int Id { get; set; }

        [Description("用户名")]
        public string Name = null!;
    }

    public class TestGetAttr
    {
        [Fact]
        public void TestGetSelfDescription()
        {
            Assert.Equal("展示类", typeof(Demo).GetSelfDescriptions()[0]);

            Assert.Equal("主键id", typeof(Demo).GetDescriptionsByPropertyName("Id")[0]);

            Assert.Equal("用户名", typeof(Demo).GetDescriptionsByFieldName("Name")[0]);
        }
    }
}
