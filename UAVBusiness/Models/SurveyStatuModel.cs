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
    
    public partial class SurveyStatusModel
    {
      
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<SurveyModel> SurveysModel { get; set; }
    }
}
