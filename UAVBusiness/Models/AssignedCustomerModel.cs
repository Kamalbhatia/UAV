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

    public partial class AssignedCustomerModel
    {


        public long Id { get; set; }
        [Required(ErrorMessage = "Customer name is required")]
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Pilot name is required")]
        public long PilotID { get; set; }
        public string PilotName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual UserProfileModel UserProfileModel { get; set; }

    }



}
