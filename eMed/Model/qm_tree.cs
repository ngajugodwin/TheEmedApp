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
    
    public partial class qm_tree
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public qm_tree()
        {
            this.qm_sop = new HashSet<qm_sop>();
        }
    
        public int qm_tree_id { get; set; }
        public Nullable<int> creator_id { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string title { get; set; }
        public byte[] icon { get; set; }
        public string childs { get; set; }
        public Nullable<bool> isChild { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<qm_sop> qm_sop { get; set; }
    }
}