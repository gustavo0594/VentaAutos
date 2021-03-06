﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VentasEntities : DbContext
    {
        public VentasEntities()
            : base("name=VentasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CEstadoArticulo> CEstadoArticulo { get; set; }
        public virtual DbSet<CMarcaVehiculo> CMarcaVehiculo { get; set; }
        public virtual DbSet<CPeriodoPago> CPeriodoPago { get; set; }
        public virtual DbSet<CTipoArticulo> CTipoArticulo { get; set; }
        public virtual DbSet<CTipoPago> CTipoPago { get; set; }
        public virtual DbSet<CTipoVehiculo> CTipoVehiculo { get; set; }
        public virtual DbSet<CTipoVenta> CTipoVenta { get; set; }
        public virtual DbSet<CTransmision> CTransmision { get; set; }
        public virtual DbSet<TArticulo> TArticulo { get; set; }
        public virtual DbSet<TCliente> TCliente { get; set; }
        public virtual DbSet<TFinanciamiento> TFinanciamiento { get; set; }
        public virtual DbSet<TPagoFinanciamiento> TPagoFinanciamiento { get; set; }
        public virtual DbSet<TTelefonoCliente> TTelefonoCliente { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }
        public virtual DbSet<TVehiculo> TVehiculo { get; set; }
        public virtual DbSet<TVenta> TVenta { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TPagos> TPagos { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int InsertarVentaFinanciamiento(Nullable<decimal> monto, Nullable<System.DateTime> fecha, Nullable<int> idTipoVenta, Nullable<int> idCliente, Nullable<decimal> saldo, string placa, Nullable<decimal> interes, Nullable<short> plazo, Nullable<int> idPeriodoPago, string descripcion, ObjectParameter idVenta)
        {
            var montoParameter = monto.HasValue ?
                new ObjectParameter("Monto", monto) :
                new ObjectParameter("Monto", typeof(decimal));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var idTipoVentaParameter = idTipoVenta.HasValue ?
                new ObjectParameter("IdTipoVenta", idTipoVenta) :
                new ObjectParameter("IdTipoVenta", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("Saldo", saldo) :
                new ObjectParameter("Saldo", typeof(decimal));
    
            var placaParameter = placa != null ?
                new ObjectParameter("Placa", placa) :
                new ObjectParameter("Placa", typeof(string));
    
            var interesParameter = interes.HasValue ?
                new ObjectParameter("Interes", interes) :
                new ObjectParameter("Interes", typeof(decimal));
    
            var plazoParameter = plazo.HasValue ?
                new ObjectParameter("Plazo", plazo) :
                new ObjectParameter("Plazo", typeof(short));
    
            var idPeriodoPagoParameter = idPeriodoPago.HasValue ?
                new ObjectParameter("IdPeriodoPago", idPeriodoPago) :
                new ObjectParameter("IdPeriodoPago", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarVentaFinanciamiento", montoParameter, fechaParameter, idTipoVentaParameter, idClienteParameter, saldoParameter, placaParameter, interesParameter, plazoParameter, idPeriodoPagoParameter, descripcionParameter, idVenta);
        }
    
        [DbFunction("VentasEntities", "VehiculosDisponibles")]
        public virtual IQueryable<VehiculosDisponibles_Result> VehiculosDisponibles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<VehiculosDisponibles_Result>("[VentasEntities].[VehiculosDisponibles]()");
        }
    }
}
