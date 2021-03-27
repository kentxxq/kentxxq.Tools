using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace kentxxq.Utils
{
    public static class LDAP
    {
        /// <summary>
        /// 测试ldap连接<br/>
        /// 等linux上实现了ssl，才能支持636端口 https://github.com/dotnet/runtime/issues/43890
        /// </summary>
        /// <param name="server">服务器地址 ldap.kentxxq.com</param>
        /// <param name="port">端口号 389/636</param>
        /// <param name="userDN">完整的用户DN cn=username,dc=ldap,dc=kentxxq,dc=com</param>
        /// <param name="password">密码 password</param>
        /// <param name="verifySSL">是否验证ssl证书 默认不验证，因为很多都是自签发的。如果需要验证，请在客户端机器导入证书。</param>
        /// <returns>状态正常为true，否则false</returns>
        public static bool VerifyLdapConnection(string server, int port, string userDN, string password, bool verifySSL = false)
        {
            try
            {
                LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier(server, port);
                using (LdapConnection ldapConnection = new LdapConnection(ldi))
                {
                    ldapConnection.AuthType = AuthType.Basic;
                    if (port == 636)
                    {
                        ldapConnection.SessionOptions.SecureSocketLayer = true;
                    }
                    if (!verifySSL)
                    {
                        ldapConnection.SessionOptions.VerifyServerCertificate = (_, _) => { return true; };
                    }
                    ldapConnection.SessionOptions.ProtocolVersion = 3;
                    NetworkCredential nc = new NetworkCredential(userDN, password);
                    ldapConnection.Bind(nc);
                }
                return true;
            }
            catch (LdapException e)
            {
                Console.WriteLine("\r\nUnable to login:\r\n\t" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + e.GetType() + ":" + e.Message);
                return false;
            }
        }
    }
}
