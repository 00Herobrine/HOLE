using System.ComponentModel;
using System.Reflection;
using HOLE.Assets.Scripts.Mods;

namespace HOLE.Assets.Scripts.Utils;

public static class Extensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());
        if (fi == null) return "NULL";
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }

    public static bool IsValid(this Instance instance)
    {
        return Path.Exists(instance.BepInExPath)
            && Path.Exists(instance.ServerExePath);
    }

    public static VersionStatus VersionComparison(string newVersion, string oldVersion) => VersionComparison(Version.Parse(newVersion), Version.Parse(oldVersion));
    public static VersionStatus VersionComparison(Version version1, Version version2)
    {
        int state = version1.CompareTo(version2);
        return state switch
        {
            0 => VersionStatus.Match,
            1 => VersionStatus.Newer,
            -1 => VersionStatus.Outdated,
            _ => VersionStatus.None,
        };
    }
}