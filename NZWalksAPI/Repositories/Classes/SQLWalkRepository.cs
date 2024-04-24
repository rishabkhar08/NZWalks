using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Repositories.Classes
{
    public class SQLWalkRepository: IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            var walksDomain = _dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();
            //var walksDomain = await _dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync();

            // Filtering
            if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery) )
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = walksDomain.Where(x => x.Name != null && x.Name.Contains(filterQuery));
                }
                else if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = walksDomain.Where(x => x.Description != null && x.Description.Contains(filterQuery));
                }
            }

            // Sorting
            if(!string.IsNullOrWhiteSpace(sortBy))
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                   walksDomain = isAscending == true ? walksDomain.OrderBy(x => x.Name) : walksDomain.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = isAscending == true ? walksDomain.OrderBy(x => x.LengthInKm) : walksDomain.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Pagination
            walksDomain = walksDomain.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await walksDomain.ToListAsync();
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            var walkDomain = await _dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
            return walkDomain;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FindAsync(id);
            if (existingWalk != null) 
            {
                existingWalk.Name = walk.Name;
                existingWalk.Description = walk.Description;
                existingWalk.LengthInKm = walk.LengthInKm;
                existingWalk.WalkImageUrl = walk.WalkImageUrl;
                existingWalk.DifficultyId = walk.DifficultyId;
                existingWalk.RegionId = walk.RegionId;
            }

            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkDomain = await _dbContext.Walks.FindAsync(id);
            if(walkDomain == null) 
            {
                return null;
            }
            _dbContext.Walks.Remove(walkDomain);
            await _dbContext.SaveChangesAsync();

            return walkDomain;
        }

    }
}
