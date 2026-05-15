namespace FinTracker.Parser.Models;

public class ParseResult
{
    public List<ParsedTransaction> Transactions { get; set; } = [];
    public List<ParseError> Errors { get; set; } = [];
}
