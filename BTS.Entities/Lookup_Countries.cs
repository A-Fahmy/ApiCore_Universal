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
    
    public partial class Lookup_Countries
    {
        public int Code { get; set; }
        public string CountryNameAr { get; set; }
        public string CountryNameEn { get; set; }
        public bool IsActive { get; set; }
        public string CurrencyISOCode { get; set; }
        public decimal ExchangeRateToEGP { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencyNameEn { get; set; }
        public byte[] Photo { get; set; }
        public string KeyInternational { get; set; }
        public Nullable<bool> RegionalYN { get; set; }
        public Nullable<bool> StartBusinessYN { get; set; }
    }
}