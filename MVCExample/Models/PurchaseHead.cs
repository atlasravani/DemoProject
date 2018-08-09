//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCExample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseHead()
        {
            this.PurchaseLines = new HashSet<PurchaseLine>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> StaffID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseLine> PurchaseLines { get; set; }
    }
}