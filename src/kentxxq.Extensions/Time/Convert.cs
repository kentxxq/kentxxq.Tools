using System;

namespace kentxxq.Extensions.Time
{
    public static class Convert
    {
        /// <summary>
        /// 转换为unix下的timestamp
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimeMilliseconds(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
    }
}
