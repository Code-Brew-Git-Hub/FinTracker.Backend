
namespace FinTracker.Domain.Models.ModelsToHelp;

public class BulkUpdateData
{
    public Guid? CategoryId { get; set; }
    public Guid? ScopeId { get; set; }
    public string? Comment { get; set; }
    public List<Guid>? AddTagIds { get; set; }
    public List<Guid>? ReplaceTagIds { get; set; }
}
