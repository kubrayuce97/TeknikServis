//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kübra
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLURUNTAKIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLURUNTAKIP()
        {
            this.TBLARIZADETAY = new HashSet<TBLARIZADETAY>();
        }
    
        public int TAKIPID { get; set; }
        public string ACIKLAMA { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public string SERINO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLARIZADETAY> TBLARIZADETAY { get; set; }
    }
}
