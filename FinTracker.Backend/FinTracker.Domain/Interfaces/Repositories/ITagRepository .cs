using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface ITagRepository : IRepository<Tag>
{
    Task<IEnumerable<Tag>> GetByNamesAsync(IEnumerable<string> names);
}
