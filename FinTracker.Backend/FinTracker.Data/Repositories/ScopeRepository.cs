using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public class ScopeRepository(AppContext context) : IScopeRepository
    {
        public async Task AddAsync(Scope scope, CancellationToken cancellationToken = default)
        {
            await context.Scopes.AddAsync(scope, cancellationToken);
            await context.SaveChangesAsync();
        }

        public async Task<Scope?> GetScopeByName(string name)
        {
            return context.Scopes.AsQueryable().Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
