//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TFinanciamiento
    {
        public int IdFinanciamiento { get; set; }
        public short Interes { get; set; }
        public short Plazo { get; set; }
        public int IdPeriodoPago { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdVenta { get; set; }
    
        public virtual CPeriodoPago CPeriodoPago { get; set; }
        public virtual TVenta TVenta { get; set; }
    }
}
