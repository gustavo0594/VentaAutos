//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaAutos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TFinanciamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TFinanciamiento()
        {
            this.TPagoFinanciamiento = new HashSet<TPagoFinanciamiento>();
        }
    
        public int IdFinanciamiento { get; set; }
        public short Interes { get; set; }
        public short Plazo { get; set; }
        public System.DateTime Monto { get; set; }
        public int IdPeriodoPago { get; set; }
        public Nullable<int> IdVenta { get; set; }
    
        public virtual CPeriodoPago CPeriodoPago { get; set; }
        public virtual TVenta TVenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TPagoFinanciamiento> TPagoFinanciamiento { get; set; }
    }
}
