//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eMed.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resource
    {
        public int UniqueID { get; set; }
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public Nullable<int> Color { get; set; }
        public byte[] Image { get; set; }
        public string CustomField1 { get; set; }
    }
}
