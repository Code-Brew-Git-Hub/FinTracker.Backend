using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public class ScopeRepository : IScopeRepository
    {
        public Task AddAsync(Scope scope, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Scope>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Scope> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Scope scope, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
