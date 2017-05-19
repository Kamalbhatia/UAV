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
    
    public partial class DroneEquipmentModel
    {
    
        public int ID { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }

        public virtual ICollection<SurveyModel> SurveysModel { get; set; }
    }
}
