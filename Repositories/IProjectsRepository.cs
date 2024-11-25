using Microsoft.AspNetCore.Mvc;
using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;
namespace RemoteMultiSiteMobileBasedExpenseManager.Repositories
{
    public interface IProjectsRepository
    {
        Task<Projects> CreateProject(Projects objProject);
        Projects UpdateProject(Int64 IdProject);
        bool DeleteProject(Int64 IdProject);
        IQueryable<Projects> ListAllProjects(Int64 IdUser);
        IQueryable<Projects> GetProjectById(int IdUser);
    }
}
