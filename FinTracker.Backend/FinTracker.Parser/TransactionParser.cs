using FinTracker.Domain.Models;

namespace FinTracker.Parser;

public class TransactionParser
{
    public async Task<List<Transaction>> Parse(StreamReader reader, string filename)
    {
        var extension = Path.GetExtension(filename).ToLowerInvariant();

        switch (extension)
        {
            case ".csv":
                var parser = new CsvParser();
                return await parser.ParseCSV(reader);
            //case "xls":
            //    var parser = new ExcelParser();
            //    return await parser.ParseExcel(reader);

            default:
                return new List<Transaction>();
        }

    }
}
