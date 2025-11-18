using CondoLounge.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Entities.Building>, Data.Interfaces.IBuildingRepository
    {

        private readonly ApplicationDbContext _context;
       
        
        public BuildingRepository(ApplicationDbContext context, ILogger<CondoLoungeGenericGenericRepository<Entities.Building>> logger) : base(context, logger) 
        { 
            _context = context;
        }


        public async Task<IEnumerable<Condo>> GetCondosForBuildingAsync(string buildingId)
        {
            return await _context.Condos
                .Where(c => c.BuildingId == buildingId)
                .ToListAsync();
        }


        public async Task<IEnumerable<ApplicationUser>> GetUsersForBuildingAsync(string buildingId)
        {
            return await _context.Users
                .Where(u => u.Condos.Any(c => c.BuildingId == buildingId))
                .ToListAsync();
        }



    }
}
