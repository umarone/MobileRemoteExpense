using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels
{
    [Table("Projects", Schema = "Setup")]
    public class ProjectUser
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdProjectUser { get; set; }
        public Int64 IdUser { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
