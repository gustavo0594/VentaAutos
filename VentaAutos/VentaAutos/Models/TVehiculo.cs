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
    
    public partial class TVehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TVehiculo()
        {
            this.TVenta = new HashSet<TVenta>();
        }
    
        public string Placa { get; set; }
        public int IdMarca { get; set; }
        public int Anio { get; set; }
        public string Estilo { get; set; }
        public Nullable<short> IdTransmision { get; set; }
        public string Modelo { get; set; }
        public Nullable<byte> NumPuertas { get; set; }
        public int IdTipoVehiculo { get; set; }
        public decimal Valor { get; set; }
        public int IdTipoArticulo { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<int> IdCliente { get; set; }
    
        public virtual CEstadoArticulo CEstadoArticulo { get; set; }
        public virtual CMarcaVehiculo CMarcaVehiculo { get; set; }
        public virtual CTipoArticulo CTipoArticulo { get; set; }
        public virtual CTipoVehiculo CTipoVehiculo { get; set; }
        public virtual CTransmision CTransmision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TVenta> TVenta { get; set; }
        public virtual TCliente TCliente { get; set; }
    }
}
