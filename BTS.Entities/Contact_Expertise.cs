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
    
    public partial class Contact_Expertise
    {
        public int Code { get; set; }
        public int ContactCode { get; set; }
        public int ExpertiseRCLCode { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> EntriyRootExpertise { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> OldExpertiseRCLCode { get; set; }
    }
}