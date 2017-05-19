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
    
    public partial class SurveyModel
    {
        public long RowNumber { get; set; }
        public long ID { get; set; }
        public string Title { get; set; }
        public System.DateTime SurveyDate { get; set; }
        public System.TimeSpan SurveyTime { get; set; }
        public long CustomerID { get; set; }
       
        public long CustomerLocationID { get; set; }
        public int PilotID { get; set; }
        public int DroneID { get; set; }
        public int SurveyStatusID { get; set; }
        public string EC_ATC { get; set; }
        public string EC_LocalPolice { get; set; }
        public string EC_FireBrigde { get; set; }
        public string EC_AE { get; set; }
       
        public string WC_Wind { get; set; }
        public string WC_Precipitation { get; set; }
        public string WC_Visibility { get; set; }
        public string WC_CloudCover { get; set; }
        public string WC_KP { get; set; }
       
        public string W_SunRise { get; set; }
        public string W_SunSet { get; set; }
        public string W_CTAFS { get; set; }
        public string W_WindSpeed { get; set; }
        public string W_Prepreciption { get; set; }
        public string W_Temperature { get; set; }
        public string W_Notams { get; set; }
       
        public string SH_NotedStructure { get; set; }
        public string SH_PedestrainRisk { get; set; }
        public string SH_VehileRisk { get; set; }
        public string SH_ATR { get; set; }
        public string SH_ExplosiveRisk { get; set; }
        
        public string MS_Name { get; set; }
        public string MS_Telephone { get; set; }
        public string MS_Email { get; set; }
       
        public System.DateTime FT_StartTime { get; set; }
        public System.DateTime FT_EndTime { get; set; }
        public System.DateTime TimeHack { get; set; }
       
        public string NearAreaPopulation { get; set; }
        public string SiteAddress { get; set; }
        public string OperatingArea { get; set; }
        public string Question { get; set; }
        public string WorkDescription { get; set; }
        public string Comments { get; set; }
       
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }

        public virtual CustomerModel CustomerModel { get; set; }
        public virtual CustomerLocationModel CustomerLocationModel { get; set; }
        public virtual DroneEquipmentModel DroneEquipmentModel { get; set; }
        public virtual PilotModel PilotModel { get; set; }
        public virtual SurveyStatusModel SurveyStatuModel { get; set; }
        public virtual ICollection<SurveyImageModel> SurveyImagesModel { get; set; }


        public string CustomerName { get; set; }
    
    }
}
