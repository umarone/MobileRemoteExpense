using Microsoft.AspNetCore.Identity;
namespace RemoteMultiSiteMobileBasedExpenseManager.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? IdParentUser { get; set; }
        public Int64 IdProject { get; set; }
        public Int64 IdOrganization { get; set; }
        public string? Address { get; set; }
    }
}
