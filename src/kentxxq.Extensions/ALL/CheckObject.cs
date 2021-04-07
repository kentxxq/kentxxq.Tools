using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kentxxq.Extensions.ALL
{
    public static class CheckObject
    {
        /// <summary>
        /// 检查所有的属性存在null或""空字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool AnyEmptyOrNull<T>(this T o)
        {
            var t = o.GetType();
            var properties = t.GetProperties();
            foreach (var porperty in properties)
            {
                if (porperty.GetValue(o) == null || porperty.GetValue(o).ToString() == "")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
