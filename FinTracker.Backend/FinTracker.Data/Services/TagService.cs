
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;

namespace FinTracker.Data.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{

}
