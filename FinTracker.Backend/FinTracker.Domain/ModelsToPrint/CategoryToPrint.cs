using FinTracker.Domain.Models;

namespace FinTracker.Domain.ModelsToPrint;

public class CategoryToPrint
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public CategoryToPrint(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}
