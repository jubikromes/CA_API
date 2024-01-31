using System;
using System.ComponentModel;
using System.Linq;
namespace Shared.Extensions;

public static class EnumExtensions
{
    public static List<string> GetEnumValues<T>()
    {
        if (!typeof(T).IsEnum) throw new ArgumentException();

        var values = Enum.GetValues(typeof(T)).Cast<string>().ToList();

        return values;
    }

    public static List<KeyValuePair<TEnum, string>> GetList<TEnum>()
    {
        if (!typeof(TEnum).IsEnum) throw new ArgumentException();

        return [.. ((TEnum[])Enum.GetValues(typeof(TEnum)))
            .ToDictionary(k => k, v => ((Enum)(object)v)
            .GetAttributeOfType<DescriptionAttribute>().Description)];
    }

    private static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());

        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }
}
