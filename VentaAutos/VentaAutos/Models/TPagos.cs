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
    
    public partial class TPagos
    {
        public int IdPago { get; set; }
        public int IdVenta { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<short> PeriodoCancelado { get; set; }
        public decimal Saldo { get; set; }
        public int IdTipoPago { get; set; }
        public decimal Monto { get; set; }
    
        public virtual CTipoPago CTipoPago { get; set; }
        public virtual TVenta TVenta { get; set; }
    }
}
