using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace kentxxq.Utils.Tests
{
    public class TestConnection
    {
        [Fact]
        public void TestTryConnectMysql()
        {
            Assert.True(Connection.TryConnectMysql("db4free.net", "kentxxq", "kentxxq_test_db", "kentxxq_test_db"));
        }
    }
}
