﻿using System.Text.Json.Serialization;
using kentxxq.Utils.Enums;

namespace kentxxq.Utils.Models;

public class Data
{
    [JsonPropertyName("area")] public string? Area { get; set; }

    [JsonPropertyName("country")] public string? Country { get; set; }

    [JsonPropertyName("isp_id")] public string? IspId { get; set; }

    [JsonPropertyName("queryIp")] public string? QueryIp { get; set; }

    [JsonPropertyName("city")] public string? City { get; set; }

    [JsonPropertyName("ip")] public string? Ip { get; set; }

    [JsonPropertyName("isp")] public string? Isp { get; set; }

    [JsonPropertyName("county")] public string? County { get; set; }

    [JsonPropertyName("region_id")] public string? RegionId { get; set; }

    [JsonPropertyName("area_id")] public string? AreaId { get; set; }

    [JsonPropertyName("county_id")] public object? CountyId { get; set; }

    [JsonPropertyName("region")] public string? Region { get; set; }

    [JsonPropertyName("country_id")] public string? CountryId { get; set; }

    [JsonPropertyName("city_id")] public string? CityId { get; set; }
}

public class IpInfo
{
    [JsonPropertyName("data")] public Data? Data { get; set; }

    [JsonPropertyName("msg")] public string? Msg { get; set; }

    [JsonPropertyName("code")] public IpInfoCode Code { get; set; }

    public override string ToString()
    {
        return string.Join("-", Data?.Country, Data?.Region, Data?.City, Data?.Isp);
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(IpInfo))]
public partial class IpInfoContext : JsonSerializerContext
{
}
