using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;
using RemoteMultiSiteMobileBasedExpenseManager.Repositories;
using RemoteMultiSiteMobileBasedExpenseManager.Common;

namespace RemoteMultiSiteMobileBasedExpenseManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectsRepository _repoProject;

        public ProjectController(IProjectsRepository repoProject)
        {
            this._repoProject = repoProject;
        }
        [Authorize]
        [Route("CreateProject")]
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Projects objProject)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                if (MiscOperations.ValidateToken(token) && HttpContext.User.Identity.IsAuthenticated)
                {
                    Int64 idUser = Convert.ToInt64(MiscOperations.GetClaimValue(HttpContext.User,"Id"));
                    var result = await _repoProject.CreateProject(objProject);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Content("Security Breach");
        }
    }
}
