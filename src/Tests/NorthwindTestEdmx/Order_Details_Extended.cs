//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthwindTestProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Details_Extended
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPriceCustom { get; set; }
        public short Quantity { get; set; }
        public float DiscountCustom { get; set; }
        public Nullable<decimal> ExtendedPrice { get; set; }
    }
}
