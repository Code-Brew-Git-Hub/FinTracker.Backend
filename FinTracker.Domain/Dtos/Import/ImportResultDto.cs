namespace FinTracker.Domain.Dtos.Import;

public class ImportResultDto
{
    public int Total { get; set; }
    public int Imported { get; set; }
    public List<ImportErrorDto> Errors { get; set; } = [];
}
