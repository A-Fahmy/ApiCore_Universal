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
    
    public partial class Lookup_Help
    {
        public int Code { get; set; }
        public string HelpTitleNameAR { get; set; }
        public string HelpTitleNameEN { get; set; }
        public Nullable<int> ParentHelpCode { get; set; }
        public string DescriptionsAR { get; set; }
        public string DescriptionsEN { get; set; }
        public bool AddDescriptionYN { get; set; }
        public bool IsActive { get; set; }
    }
}