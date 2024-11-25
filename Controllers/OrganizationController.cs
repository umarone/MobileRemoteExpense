using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteMultiSiteMobileBasedExpenseManager.Models;
using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;
using RemoteMultiSiteMobileBasedExpenseManager.Repositories;
using RemoteMultiSiteMobileBasedExpenseManager.SqlServer;
namespace RemoteMultiSiteMobileBasedExpenseManager.Controllers
{
    [ApiController]
    [Route("api/setup")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _objRepo;
        public OrganizationController(IOrganizationRepository objRepo)
        {
            _objRepo = objRepo;
        }
        [Authorize]
        [HttpPost]
        [Route("CreateOrganization")]
        public async Task<IActionResult> CreateOrganization([FromBody] Organizations objOrg)
        {
            try
            {
                if (objOrg == null)
                    return BadRequest();
                else
                {
                    var organization = await _objRepo.CreateOrganization(objOrg);
                    if (organization == null)
                        return BadRequest();
                    else
                        return Ok(organization);

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
