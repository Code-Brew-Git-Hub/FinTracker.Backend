
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FinTracker.Domain.Enums;

namespace FinTracker.Parser.Converters;

public class CategoryEnumConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null; // или другое значение по умолчанию / null

        // Используем ранее описанный метод получения enum по описанию
        if (EnumHelper<CategoryEnum>.TryGetValueByDescription(text, out var result))
            return result;

        // Если не нашли – можно вернуть значение по умолчанию или бросить исключение
        throw new TypeConverterException(null, memberMapData, text, null,
            $"Невозможно преобразовать '{text}' в {typeof(CategoryEnum).Name}");
    }
}
