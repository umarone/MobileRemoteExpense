using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemoteMultiSiteMobileBasedExpenseManager.Models.UserModels
{
    [Table("ProjectUsers", Schema = "Users")]
    public class ProjectUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IdProjectUser { get; set; }
        public Int64 IdUser { get; set; }
        public bool WorkStatus { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
