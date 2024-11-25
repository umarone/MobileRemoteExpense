using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;

namespace RemoteMultiSiteMobileBasedExpenseManager.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Organizations> CreateOrganization(Organizations objorganization);
        Organizations UpdateOrganization(Int64 IdProject);
        bool DeleteOrganization(Int64 IdProject);
        IQueryable<Organizations> ListAllOrganization(Int64 IdUser);
        IQueryable<Organizations> ListOrganizationById(Int64 IdOrganization);
    }
}
