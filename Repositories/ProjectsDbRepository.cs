using Microsoft.AspNetCore.Mvc;
using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;
using RemoteMultiSiteMobileBasedExpenseManager.SqlServer;

namespace RemoteMultiSiteMobileBasedExpenseManager.Repositories
{
    public class ProjectsDbRepository : IProjectsRepository
    {
        private readonly DbContextEntities _context;
        public ProjectsDbRepository(DbContextEntities context)
        {
            _context = context;
        }

        public async Task<Projects> CreateProject(Projects objProject)
        {
            _context.Projects.Add(objProject);
            await _context.SaveChangesAsync();
            return objProject;
        }
        public Projects UpdateProject(Int64 IdProject)
        {
            var project = _context.Projects.FirstOrDefault(x => x.IdProject == IdProject);
            if (project != null)
            {
             
                  project.IsActive = false;
                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return project!;
        }
        public bool DeleteProject(long IdProject)
        {
           var project = _context.Projects.FirstOrDefault(x => x.IdProject == IdProject);
            if (project == null)
            {
                return false;
            }
            else
            {
                project.IsActive = false;
                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return true;
        }

        public IQueryable<Projects> GetProjectById(int IdUser)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Projects> ListAllProjects(long IdUser)
        {
            throw new NotImplementedException();
        }
    }
}
