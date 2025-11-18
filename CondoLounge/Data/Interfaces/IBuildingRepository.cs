using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface IBuildingRepository: ICondoLoungeGenericRepository<Entities.Building>
    {
        Task<IEnumerable<ApplicationUser>> GetUsersForBuildingAsync(string buildingId);

        Task<IEnumerable<Condo>> GetCondosForBuildingAsync(string buildingId);
    }
}
