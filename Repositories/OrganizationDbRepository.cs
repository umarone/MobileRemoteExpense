using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;
using RemoteMultiSiteMobileBasedExpenseManager.SqlServer;

namespace RemoteMultiSiteMobileBasedExpenseManager.Repositories
{
    public class OrganizationDbRepository : IOrganizationRepository
    {
        private readonly DbContextEntities _context;
        public OrganizationDbRepository(DbContextEntities context)
        {
            _context = context;
        }
        public async Task<Organizations> CreateOrganization(Organizations objorganization)
        {
            _context.Organizations.Add(objorganization);
            await _context.SaveChangesAsync();
            return objorganization;
        }

        public Organizations UpdateOrganization(long IdProject)
        {
            throw new NotImplementedException();
        }
        public bool DeleteOrganization(long IdProject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Organizations> ListAllOrganization(long IdUser)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Organizations> ListOrganizationById(long IdOrganization)
        {
            throw new NotImplementedException();
        }
    }
}
