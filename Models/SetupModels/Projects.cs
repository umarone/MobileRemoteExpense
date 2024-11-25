using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels
{
    [Table("Projects", Schema = "Setup")]
    public class Projects 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdProject { get; set; }
        public Int64 IdOrganization { get; set; }
        [Required]
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
