namespace FinTracker.Domain.Dtos.Validation;

public class ConfirmValidationIssueDto
{
    public List<Guid> TransactionIdsToDelete { get; set; } = [];
    public string? Comment { get; set; }
}
