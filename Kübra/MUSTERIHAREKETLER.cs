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
    
    public partial class MUSTERIHAREKETLER
    {
        public int HAREKETID { get; set; }
        public Nullable<int> URUNID { get; set; }
        public Nullable<byte> ADET { get; set; }
        public Nullable<short> PERSONEL { get; set; }
        public Nullable<int> MUSTERI { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
        public Nullable<decimal> TOPLAM { get; set; }
        public Nullable<int> FATURAID { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public string NOTLAR { get; set; }
    
        public virtual TBLMUSTERILER TBLMUSTERILER { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL1 { get; set; }
        public virtual TBLURUN TBLURUN { get; set; }
    }
}
