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
    
    public partial class ExpertiseSuggestion
    {
        public int Code { get; set; }
        public Nullable<int> ContactCode { get; set; }
        public string Discreption { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Parent { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> InsertYN { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> MonthlySalary { get; set; }
    }
}
