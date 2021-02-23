//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book_History
    {
        public int Code { get; set; }
        public Nullable<int> PatrentCode { get; set; }
        public Nullable<int> RUCContactCode { get; set; }
        public Nullable<int> RCCContactCode { get; set; }
        public Nullable<int> RCCExpertise { get; set; }
        public Nullable<int> RCCRCL { get; set; }
        public string BookStatus { get; set; }
        public Nullable<int> BookDuration { get; set; }
        public Nullable<System.DateTime> BookFrom { get; set; }
        public Nullable<System.DateTime> BookTo { get; set; }
        public Nullable<decimal> BookFeesPerHr { get; set; }
        public Nullable<decimal> BookFeesAfterDis { get; set; }
        public Nullable<decimal> BookFeesbeforeDis { get; set; }
        public Nullable<System.DateTime> BookDate { get; set; }
        public Nullable<System.DateTime> BookModDate { get; set; }
        public Nullable<int> BookModBy { get; set; }
        public string BookCondition { get; set; }
        public string BookLocationName { get; set; }
        public string BookLatitude { get; set; }
        public string BookLongitude { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> StartTime { get; set; }
        public Nullable<int> EndTime { get; set; }
        public Nullable<int> RCC_ZoneOfMobility { get; set; }
        public Nullable<int> RUC_ZoneOfMobility { get; set; }
        public string RCC_Longitude { get; set; }
        public string RCC_Latitude { get; set; }
    }
}
