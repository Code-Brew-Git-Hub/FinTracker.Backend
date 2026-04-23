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
            string description = attr?.Description ?? value.ToString(); // если нет атрибута, используем имя
            _descriptionToValue[description] = value;
        }
    }

    public static T GetValueByDescription(string description)
    {
        if (_descriptionToValue.TryGetValue(description, out T result))
            return result;
        throw new ArgumentException($"Значение с описанием '{description}' не найдено в перечислении {typeof(T).Name}");
    }

    public static bool TryGetValueByDescription(string description, out T result)
    {
        return _descriptionToValue.TryGetValue(description, out result);
    }
}