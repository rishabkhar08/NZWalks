using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10);
        Task<Walk?> GetAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id,Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
