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
    
    public partial class TVenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TVenta()
        {
            this.TFinanciamiento = new HashSet<TFinanciamiento>();
            this.TVehiculo = new HashSet<TVehiculo>();
        }
    
        public int IdVenta { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdTipoVenta { get; set; }
        public int IdCliente { get; set; }
        public decimal Saldo { get; set; }
    
        public virtual CTipoVenta CTipoVenta { get; set; }
        public virtual TCliente TCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFinanciamiento> TFinanciamiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TVehiculo> TVehiculo { get; set; }
    }
}
