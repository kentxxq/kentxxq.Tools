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
            if (o == null) return true;
            var t = o.GetType();
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(o) == null || property.GetValue(o)?.ToString() == "")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查所有属性是否有一个不为null或""空字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool AnyValue<T>(this T o)
        {
            if (o == null) return true;
            var t = o.GetType();
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(o) != null || property.GetValue(o)?.ToString() != "")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
