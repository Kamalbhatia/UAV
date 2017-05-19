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
    
    public partial class CustomerLocation
    {
        public CustomerLocation()
        {
            this.SurveyImages = new HashSet<SurveyImage>();
        }
    
        public long ID { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public string LocationName { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual ICollection<SurveyImage> SurveyImages { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}