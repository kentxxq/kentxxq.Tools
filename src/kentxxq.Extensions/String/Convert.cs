using System.Net;

namespace kentxxq.Extensions.String;

public static class Convert
{
    /// <summary>
    /// 把url字符串转换成IPEndPoint
    /// </summary>
    /// <param name="url">kentxxq.com:443</param>
    /// <returns></returns>
    public static IPEndPoint UrlToIPEndPoint(this string url)
    {
        var host = url.Split(":")[0];
        var ip = Dns.GetHostAddresses(host)[0];
        var port = url.Split(":")[1];
        var ipEndPoint = new IPEndPoint(ip, int.Parse(port));
        return ipEndPoint;
    }
}
