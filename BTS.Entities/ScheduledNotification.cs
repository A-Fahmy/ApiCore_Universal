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
    
    public partial class ScheduledNotification
    {
        public int Code { get; set; }
        public Nullable<int> TargetUserCode { get; set; }
        public Nullable<int> BookingCode { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public Nullable<bool> IsSent { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
