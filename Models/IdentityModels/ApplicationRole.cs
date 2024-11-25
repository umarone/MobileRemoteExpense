using Microsoft.AspNetCore.Identity;
namespace RemoteMultiSiteMobileBasedExpenseManager.Models.IdentityModels
{
    public class ApplicationRole : IdentityRole
    {
        public string? RoleDescription { get; set; }
    }
}
