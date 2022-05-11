using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace kentxxq.Extensions.ALL;

public static class GetAttr
{
    /// <summary>
    /// 获取自身Description属性值
    /// </summary>
    /// <param name="type">任何type类型</param>
    /// <returns>所有Description值</returns>
    public static List<string> GetSelfDescriptions(this Type type)
    {
        var attrs = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attrs.Select(a => a.Description).ToList();
    }

    /// <summary>
    /// 获取通过字段名称，获取Description值
    /// </summary>
    /// <param name="type">任何type类型</param>
    /// <param name="fieldName">字段名称</param>
    /// <returns>所有Description值</returns>
    public static List<string> GetDescriptionsByFieldName(this Type type, string fieldName)
    {
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.Name == fieldName)
            {
                var attrs = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attrs.Select(a => a.Description).ToList();
            }
        }

        return new List<string>();
    }

    /// <summary>
    /// 获取通过属性名称，获取Description值
    /// </summary>
    /// <param name="type">任何type类型</param>
    /// <param name="propertyName">字段名称</param>
    /// <returns>所有Description值</returns>
    public static List<string> GetDescriptionsByPropertyName(this Type type, string propertyName)
    {
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            if (property.Name == propertyName)
            {
                var attrs = (DescriptionAttribute[])property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attrs.Select(a => a.Description).ToList();
            }
        }

        return new List<string>();
    }

    /// <summary>
    /// 获取枚举的Description值
    /// </summary>
    /// <param name="enumValue">枚举类里的值</param>
    /// <returns></returns>
    public static List<string> GetEnumDescriptions(this Enum enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var descriptionAttributes =
            (DescriptionAttribute[]?)fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false);
        descriptionAttributes ??= Array.Empty<DescriptionAttribute>();
        return descriptionAttributes.Select(d => d.Description).ToList();
    }
}
