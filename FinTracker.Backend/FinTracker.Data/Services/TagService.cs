
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{
    public Task<Tag> CreateAsync(string name)
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
}
