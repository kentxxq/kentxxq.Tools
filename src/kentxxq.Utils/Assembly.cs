using System;
using System.Linq;
using System.Reflection;

namespace kentxxq.Utils;

[Obsolete("Use ThisAssembly instead")]
public static class Assembly
{
    public static string? GetAssemblyInformationalVersion()
    {
        var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
        var info = entryAssembly?.GetCustomAttributes<AssemblyInformationalVersionAttribute>();
        return info?.FirstOrDefault()?.InformationalVersion;
    }
    
    public static string? GetAssemblyVersion()
    {
        var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
        var info = entryAssembly?.GetCustomAttributes<AssemblyVersionAttribute>();
        return info?.FirstOrDefault()?.Version;
    }
    
    public static string? GetAssemblyFileVersion()
    {
        var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
        var info = entryAssembly?.GetCustomAttributes<AssemblyFileVersionAttribute>();
        return info?.FirstOrDefault()?.Version;
    }
    
    public static string? GetNugetFullVersion(Type type)
    {
        return System.Reflection.Assembly.GetAssembly(type)?.GetName().Version?.ToString();
    }
    
    public static string? GetNugetVersion(Type type)
    {
        var fullVersion = System.Reflection.Assembly.GetAssembly(type)?.GetName().Version;
        return fullVersion != null ? $"{fullVersion.Major}.{fullVersion.Minor}.{fullVersion.Build}" : null;
    }
}
