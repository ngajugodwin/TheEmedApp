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
    
    public partial class temp_service
    {
        public int temp_service_id { get; set; }
        public int service_id { get; set; }
        public int patient_id { get; set; }
        public int creator_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
    
        public virtual patient patient { get; set; }
        public virtual service service { get; set; }
        public virtual user user { get; set; }
    }
}
