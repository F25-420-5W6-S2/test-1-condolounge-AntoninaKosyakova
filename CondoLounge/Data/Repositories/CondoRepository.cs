namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Entities.Condo>, Data.Interfaces.ICondoRepository
    {
        public CondoRepository(ApplicationDbContext context, ILogger<CondoLoungeGenericGenericRepository<Entities.Condo>> logger) : base(context, logger) { }
    }
}
