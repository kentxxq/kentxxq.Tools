using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace kentxxq.Utils;

public static class Connection
{
    /// <summary>
    /// ping测试
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static bool PingIp(IPAddress ip)
    {
        var pingSender = new Ping();
        // 32字节数据
        var data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        var buffer = Encoding.ASCII.GetBytes(data);
        var timeout = 100;
        var pingOption = new PingOptions(64, true);
        var reply = pingSender.Send(ip, timeout, buffer, pingOption);
        return reply.Status == IPStatus.Success;
    }
    
    /// <summary>
    /// ping特定主机或ip
    /// </summary>
    /// <param name="url">主机或ip地址</param>
    /// <param name="ttl">最大跳转数</param>
    /// <returns></returns>
    public static PingReply Ping(string url, int ttl=128)
    {
        var ping = new Ping();
        PingOptions pingOptions = new()
        {
            DontFragment = true,
            Ttl = ttl
        };

        const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        var buffer = Encoding.ASCII.GetBytes(data);
        const int timeout = 1000; // 毫秒
        var reply = ping.Send(url, timeout, buffer, pingOptions);

        return reply;
    }

    /// <summary>
    /// ping异步测试
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static async Task<bool> PingIpAsync(IPAddress ip)
    {
        var pingSender = new Ping();
        // 32字节数据
        var data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        var buffer = Encoding.ASCII.GetBytes(data);
        var timeout = 100;
        var pingOption = new PingOptions(64, true);
        var reply = await pingSender.SendPingAsync(ip, timeout, buffer, pingOption);
        return reply.Status == IPStatus.Success;
    }

    /// <summary>
    /// mysql同步连接测试
    /// </summary>
    /// <returns>bool值确定是否连接成功</returns>
    public static bool TryConnectMysql(string server, string username, string password, string db)
    {
        MySqlConnection conn;

        string myConnectionString;

        myConnectionString = $"server={server};uid={username};pwd={password};database={db}";
        conn = new MySqlConnection();
        var result = false;
        try
        {
            conn.ConnectionString = myConnectionString;
            conn.Open();
            result = true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            conn.Close();
        }

        return result;
    }

    /// <summary>
    /// mysql异步连接测试
    /// </summary>
    /// <returns>bool值确定是否连接成功</returns>
    public static async Task<bool> TryConnectMysqlAsync(string server, string username, string password, string db)
    {
        MySqlConnection conn;
        string myConnectionString;

        myConnectionString = $"server={server};uid={username};pwd={password};database={db}";
        conn = new MySqlConnection();
        var result = false;
        try
        {
            conn.ConnectionString = myConnectionString;
            await conn.OpenAsync();
            result = true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            await conn.CloseAsync();
        }

        return result;
    }
}
