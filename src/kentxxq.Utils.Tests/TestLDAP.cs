using Xunit;

namespace kentxxq.Utils.Tests
{
    public class TestLDAP
    {
        [Fact]
        public void TestVerifyLdapConnection()
        {
            Assert.True(LDAP.VerifyLdapConnection("ldap.kentxxq.com", 636, @"cn=admin,dc=ldap,dc=kentxxq,dc=com", "123456", true));
            Assert.True(LDAP.VerifyLdapConnection("ldap.kentxxq.com", 389, @"cn=admin,dc=ldap,dc=kentxxq,dc=com", "123456"));
        }
    }
}
