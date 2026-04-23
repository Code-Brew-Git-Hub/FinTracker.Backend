using CsvHelper;
using CsvHelper.Configuration;
using FinTracker.Domain.Models;
using FinTracker.Parser.Converters;
using System.Globalization;

namespace FinTracker.Parser;

public class CsvParser
{
    private static string TBankHeaders = "\"Дата операции\";\"Дата платежа\";\"Номер карты\";\"Статус\";\"Сумма операции\";\"Валюта операции\";\"Сумма платежа\";\"Валюта платежа\";\"Кэшбэк\";\"Категория\";\"MCC\";\"Описание\";\"Бонусы (включая кэшбэк)\";\"Округление на инвесткопилку\";\"Сумма операции с округлением\"";
    private static string AlfaBankHeaders = "operationDate,transactionDate,accountName,accountNumber,cardName,cardNumber,merchant,amount,currency,status,category,mcc,type,comment,bonusValue,bonusTitle";
    
    private CsvConfiguration Config = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU")) 
    {
        HasHeaderRecord = true,
        IgnoreBlankLines = true,
        TrimOptions = TrimOptions.Trim,
        MissingFieldFound = null,
        Delimiter = ";"
    };

    public async Task<List<Transaction>> ParseCSV(StreamReader reader)
    {
        var headers = reader.ReadLine();

        if (headers == TBankHeaders)
            return await ParseTBank(reader);
        else if (headers == AlfaBankHeaders)
            return await ParseAlfaBank(reader);

        else return new List<Transaction>();
    }

    public async Task<List<Transaction>> ParseTBank(StreamReader reader)
    {
        using var csvReader = new CsvReader(reader, Config);

        csvReader.Context.RegisterClassMap<TBankCsvMap>();

        return csvReader.GetRecords<Transaction>().ToList();

    }

    public async Task<List<Transaction>> ParseAlfaBank(StreamReader reader)
    {
        Config.Delimiter = ",";

        using var csvReader = new CsvReader(reader, Config);

        csvReader.Context.RegisterClassMap<AlfaBankCsvMap>();

        return csvReader.GetRecords<Transaction>().ToList();    
    }

    public sealed class TBankCsvMap : ClassMap<Transaction>
    {
        public TBankCsvMap()
        {
            Map(t => t.Date).Index(0);
            Map(t => t.Amount).Index(4);
            Map(t => t.Currency).Index(5);
            Map(t => t.Category).Index(9)
                .TypeConverter<CategoryEnumConverter>(); ;
            Map(t => t.Description).Index(11);
            //Map(t => t.From).Index();
            //Map(t => t.To).Index();

            // Type, Scope, Comment, IsDeleted задаются в сервисе вручную
        }
    }

    public sealed class AlfaBankCsvMap : ClassMap<Transaction>
    {
        public AlfaBankCsvMap()
        {
            Map(t => t.Date).Index(0)
                .TypeConverterOption.Format("dd.MM.yyyy");
            Map(t => t.Amount).Index(7)
                .TypeConverterOption.NumberStyles(NumberStyles.Any)
                .TypeConverterOption.CultureInfo(CultureInfo.InvariantCulture);
            Map(t => t.Currency).Index(8);
            Map(t => t.Category).Index(10)
                .TypeConverter<CategoryEnumConverter>(); ;
            //Map(t => t.From).Index();
            //Map(t => t.To).Index();

            // Type, Scope, Comment, IsDeleted задаются в сервисе вручную
            // Description отсутствует
        }
    }
}
