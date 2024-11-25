using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.Linq;

namespace RemoteMultiSiteMobileBasedExpenseManager.Models.UserModels
{
    [Table("Users", Schema = "Users")] 
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? IdUser { get; set; }
        public Int64? IdParent { get; set; }
        //[Required(ErrorMessage = "User Name Is Required")]
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string? Password { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public bool? UserStatus { get; set; }
        public bool? IsLoggedIn { get; set; }
    }
}
