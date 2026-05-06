using FinTracker.Parser.Models;

namespace FinTracker.Parser;

public class TransactionParser
{
    public async Task<ParseResult> Parse(StreamReader reader, string filename)
    {
        var extension = Path.GetExtension(filename).ToLowerInvariant();

        return extension switch
        {
            ".csv" => await new CsvParser().ParseCSV(reader),
            _ => new ParseResult() { Errors = new() { new() { Reason = "Не поддерживаемый тип файла" } } }
        };
    }
}
