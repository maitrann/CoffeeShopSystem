//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI_CoffeeShop.Utilities
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceDetail
    {
        public int id { get; set; }
        public Nullable<int> idInvoice { get; set; }
        public Nullable<int> idCart { get; set; }
        public Nullable<int> isStatus { get; set; }
        public Nullable<System.DateTime> dateSuppC { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
