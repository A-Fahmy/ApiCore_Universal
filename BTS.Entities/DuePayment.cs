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
    
    public partial class DuePayment
    {
        public int Code { get; set; }
        public int BookingCode { get; set; }
        public int ContactCode { get; set; }
        public int BankBranchCode { get; set; }
        public string ReportName { get; set; }
        public System.DateTime GeneratingDate { get; set; }
        public bool IsSent { get; set; }
    }
}
