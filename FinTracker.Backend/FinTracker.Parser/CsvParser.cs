using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using FinTracker.Domain.Models;

namespace FinTracker.Parser;

public class CsvParser
{
    public List<Transaction> ParseCSV(StreamReader reader)
    {
        var config = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
        {
            HasHeaderRecord = true,
            IgnoreBlankLines = true,  // Скипать пустые строки | Наверное не нужно здесь
            TrimOptions = TrimOptions.Trim,
            MissingFieldFound = null,
            Delimiter = ";"
        };

        using var csvReader = new CsvReader(reader, config);

        // Регистрируем явный маппинг русских колонок → свойства модели
        csvReader.Context.RegisterClassMap<TransactionCsvMap>();

        return csvReader.GetRecords<Transaction>().ToList();
    }

    public sealed class TransactionCsvMap : ClassMap<Transaction>
    {
        public TransactionCsvMap()
        {
            Map(t => t.Date).Name("Дата операции");
            Map(t => t.Amount).Name("Сумма операции");
            Map(t => t.Currency).Name("Валюта операции");
            Map(t => t.Description).Name("Описание");
            Map(t => t.Category).Name("Категория");
            // Comment, Source, Type — не в CSV, задаются в сервисе вручную
        }
    }
}
