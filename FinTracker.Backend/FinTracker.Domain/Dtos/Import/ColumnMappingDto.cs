using System.ComponentModel.DataAnnotations;

namespace FinTracker.Domain.Dtos.Import;

public class ColumnMappingDto
{
    // Значение — название колонки из файла
    [Required] public string Amount { get; set; }
    [Required] public string Date { get; set; }
    public string? Currency { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Category { get; set; }
}
