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
    
    public partial class messaging
    {
        public int messaging_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<int> port_nr { get; set; }
        public string server_address { get; set; }
        public Nullable<int> sslEnabled { get; set; }
    }
}