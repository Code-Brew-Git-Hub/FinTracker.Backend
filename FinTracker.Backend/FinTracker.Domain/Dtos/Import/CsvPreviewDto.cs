namespace FinTracker.Domain.Dtos.Import;

public class CsvPreviewDto
{
    // Колонки, которые нашли в файле
    public List<string> Columns { get; set; } = [];
    // Первые несколько строк для наглядности
    public List<Dictionary<string, string>> SampleRows { get; set; } = [];
}