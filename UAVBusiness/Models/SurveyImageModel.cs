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

    public partial class SurveyImageModel
    {
        public long ID { get; set; }
        public long SurveyID { get; set; }
        public long CustomerLocationID { get; set; }
        public string OriginalImageName { get; set; }
        public string ImageName { get; set; }
        public string ModifiedImageName { get; set; }
        public string Finding { get; set; }
        public string Recommentation { get; set; }
        public Nullable<bool> CanMitieRepair { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual CustomerLocationModel CustomerLocationModel { get; set; }
        public virtual SurveyModel SurveyModel { get; set; }
    }
}
