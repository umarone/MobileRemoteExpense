using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels
{
    [Table("Organizations", Schema = "Setup")]
    public class Organizations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdOrganization { get; set; }
        [Required]
        public Int64 IdUSer { get; set; }
        public string? OrganizationName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
