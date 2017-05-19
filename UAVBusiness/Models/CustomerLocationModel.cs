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
    
    public partial class CustomerLocationModel
    {
       
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public long CustomerID { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }

        public virtual CustomerModel CustomerModel { get; set; }
        public virtual ICollection<SurveyModel> SurveysModel { get; set; }
        public virtual ICollection<SurveyImageModel> SurveyImagesModel { get; set; }
   
    }
}
