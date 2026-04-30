using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;

namespace FinTracker.Data.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
    }
}
