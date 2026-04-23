using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FinTracker.Domain.Enums;

public static class EnumHelper<T> where T : Enum
{
    private static readonly Dictionary<string, T> _descriptionToValue;

    static EnumHelper()
    {
        _descriptionToValue = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            var field = typeof(T).GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>(false);
            string description = attr?.Description ?? value.ToString();
            _descriptionToValue[description] = value;
        }
    }

    public static T GetValueByDescription(string description)
    {
        if (_descriptionToValue.TryGetValue(description, out var result))
            return result;
        throw new ArgumentException($"Описание '{description}' не найдено в перечислении {typeof(T).Name}");
    }

    public static bool TryGetValueByDescription(string description, out T result)
    {
        return _descriptionToValue.TryGetValue(description, out result);
    }
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field?.GetCustomAttribute<DescriptionAttribute>(false);
        return attr?.Description ?? value.ToString();
    }
}