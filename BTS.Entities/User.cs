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
    
    public partial class User
    {
        public int Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string Email { get; set; }
        public string Moblie { get; set; }
        public string NationalID { get; set; }
    }
}