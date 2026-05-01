
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories;

public class TagRepository(AppDbContext context) : ITagRepository
{
    public Task AddAsync(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tag>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tag?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tag>> GetByNamesAsync(IEnumerable<string> names)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Tag entity)
    {
        throw new NotImplementedException();
    }
}
