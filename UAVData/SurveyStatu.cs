//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UAVData
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveyStatu
    {
        public SurveyStatu()
        {
            this.Surveys = new HashSet<Survey>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
