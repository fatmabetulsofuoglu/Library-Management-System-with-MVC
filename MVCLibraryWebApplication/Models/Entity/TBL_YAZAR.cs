//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLibraryWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_YAZAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_YAZAR()
        {
            this.TBL_KITAP = new HashSet<TBL_KITAP>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string DETAY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_KITAP> TBL_KITAP { get; set; }
    }
}
