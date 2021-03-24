using System;

namespace kentxxq.Utils.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = LDAP.VerifyLdapConnection("ldap.kentxxq.com", 636, @"cn=admin,dc=ldap,dc=kentxxq,dc=com", "123456");
            Console.WriteLine(result);
        }
    }
}
