using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UAVBusiness.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UserProfileModel
    {
        public long UserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "Phone id requiresd")]
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }

    public partial class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public bool RememberMe { get; set; }
      
 
    }

}
