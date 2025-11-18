namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Entities.Building>, Data.Interfaces.IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext context, ILogger<CondoLoungeGenericGenericRepository<Entities.Building>> logger) : base(context, logger) { }
    }
}
