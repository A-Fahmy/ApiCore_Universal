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
    
    public partial class Contact_WorkPlaces
    {
        public int Code { get; set; }
        public Nullable<int> ContactCode { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string Address { get; set; }
        public int CityCode { get; set; }
        public Nullable<int> ZoneOfMobility { get; set; }
        public Nullable<int> LOVCode { get; set; }
        public string LocationName { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsProposed { get; set; }
    }
}
