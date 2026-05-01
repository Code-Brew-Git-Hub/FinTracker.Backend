using System.ComponentModel.DataAnnotations;

namespace FinTracker.Domain.Dtos.Import;

public class CsvImportDto
{
    [Required] public ColumnMappingDto Mapping { get; set; }
    public string? Delimiter { get; set; } = ",";
}
