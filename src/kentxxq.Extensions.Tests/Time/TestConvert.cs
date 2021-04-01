using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using kentxxq.Extensions.Time;

namespace kentxxq.Extensions.Tests.Time
{
    public class TestConvert
    {
        //private static readonly DateTime dateTime = new(1993, 7, 6);

        [Fact]
        public void TestToUnixTimeMilliseconds()
        {
            DateTime dateTime = new(1993, 7, 6);
            var result = dateTime.ToUnixTimeMilliseconds();
            long expected = 741888000000;
            Assert.Equal(expected, result);
        }
    }
}
