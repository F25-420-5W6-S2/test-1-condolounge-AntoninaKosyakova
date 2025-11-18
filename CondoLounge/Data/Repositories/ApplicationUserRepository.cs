namespace CondoLounge.Data.Repositories
{
    public class ApplicationUserRepository :CondoLoungeGenericGenericRepository<Entities.ApplicationUser>, Data.Interfaces.IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context, ILogger<CondoLoungeGenericGenericRepository<Entities.ApplicationUser>> logger) : base(context, logger) { }
    }
}
