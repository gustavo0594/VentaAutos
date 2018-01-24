using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaAutos.Models;
using System.Configuration;
using System.Web.Configuration;

namespace VentaAutos.Controllers
{
    public class VentasController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Ventas
        public async Task<ActionResult> Index()
        {
            var tVenta = db.TVenta.Include(t => t.CTipoVenta).Include(t => t.TCliente).Include(t => t.TVehiculo);
            return View(await tVenta.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = await db.TVenta.FindAsync(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            return View(tVenta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion");
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");
            //ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo");
            CargarComboClientes(null);
            CargarComboVehiculos(string.Empty);

            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "IdVenta,Monto,Fecha,IdTipoVenta,IdCliente,Saldo,Placa,Interes,Financiamiento")] TVenta tVenta)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        //string plazo = tVenta.Financiamiento.Plazo.ToString();

        //        db.TVenta.Add(tVenta);

        //        await db.SaveChangesAsync();

        //        //revisar que el web config este seteado con el mismo idtipofinanciamiento de la BD tabla ctipoVenta (2)
        //        if (tVenta.IdTipoVenta == Int32.Parse(WebConfigurationManager.AppSettings["TipoVentaFinanciamiento"]))
        //            return RedirectToAction("Create", "Financiamientos", new { idVenta = tVenta.IdVenta });

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
        //    ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
        //    ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
        //    return View(tVenta);
        //}
               

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(FormCollection formData )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string saldo = formData["Saldo"];
        //        string plazo = formData["Financiamiento.Plazo"]; 
        //        //db.TVenta.Add(tVenta);
        //        //await db.SaveChangesAsync();

        //        ////revisar que el web config este seteado con el mismo idtipofinanciamiento de la BD tabla ctipoVenta (2)
        //        //if (tVenta.IdTipoVenta == Int32.Parse(WebConfigurationManager.AppSettings["TipoVentaFinanciamiento"]))
        //        //    return RedirectToAction("Create", "Financiamientos", new { idVenta = tVenta.IdVenta });

        //        //return RedirectToAction("Index");
        //    }

        //    //ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
        //    //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
        //    //ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
        //    return View();
        //}

        // GET: Ventas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = await db.TVenta.FindAsync(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            //ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
            CargarComboClientes(tVenta.IdCliente);
            CargarComboVehiculos(tVenta.Placa);
            return View(tVenta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdVenta,Monto,Fecha,IdTipoVenta,IdCliente,Saldo,Placa,Interes")] TVenta tVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVenta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
            return View(tVenta);
        }

        // GET: Ventas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = await db.TVenta.FindAsync(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            return View(tVenta);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> GetVehiculo( String placa)
        //(Nullable<decimal> monto, Nullable<System.DateTime> fecha, Nullable<int> idTipoVenta, Nullable<int> idCliente, Nullable<decimal> saldo, 
        //string placa, Nullable<decimal> interes, Nullable<short> plazo, Nullable<int> idPeriodoPago, string descripcion)
        public async Task<Boolean> InsertarVentaFinanciamiento(string pmonto, string pfecha, string pidTipoVenta, string pidCliente, string psaldo,
        string pplaca, string pinteres, string pplazo)
        {
            //if (placa == null)
            //{
            //    // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    return false;
            //}

            try
            {
                Decimal monto = Convert.ToDecimal(pmonto);
                DateTime fecha = Convert.ToDateTime(pfecha);
                int idTipoVenta = Convert.ToInt32(pidTipoVenta);
                int idCliente = Convert.ToInt32(pidCliente);

                if (idTipoVenta == 2)
                {//financiamiento
                    if (pplazo != null)
                    {
                        if (pplazo != string.Empty)
                        {
                             
                            pplazo = pplazo.Substring(0, pplazo.IndexOf(" Meses"));
                        }
                    }
                    Decimal saldo = Convert.ToDecimal(psaldo);
                    Decimal interes = Convert.ToDecimal(pinteres);
                    Int16 plazo = Convert.ToInt16(pplazo);
                    System.Data.Entity.Core.Objects.ObjectParameter returnId = new System.Data.Entity.Core.Objects.ObjectParameter("idVenta", typeof(int)); //Create Object parameter to receive a output value.It will behave like output parameter  

                    int venta = db.InsertarVentaFinanciamiento(monto, fecha, idTipoVenta, idCliente, saldo, pplaca, interes, plazo, 1, " ", returnId);
                    if (int.Parse(returnId.Value.ToString()) > 0)
                    {
                        RedirectToAction("Index");
                        return true;
                    }
                }
                else
                {// contado
                    TVenta tVenta = new TVenta();
                    tVenta.Monto = Convert.ToDecimal(pmonto);
                    tVenta.Fecha = Convert.ToDateTime(pfecha);
                    tVenta.IdTipoVenta = Convert.ToInt32(pidTipoVenta);
                    tVenta.IdCliente = Convert.ToInt32(pidCliente);
                    tVenta.Placa = pplaca;
                    tVenta.Saldo = tVenta.Monto;

                    db.TVenta.Add(tVenta);
                    await db.SaveChangesAsync();
                    RedirectToAction("Index");
                    return true;

                    //revisar que el web config este seteado con el mismo idtipofinanciamiento de la BD tabla ctipoVenta (2)
                    //if (tVenta.IdTipoVenta == Int32.Parse(WebConfigurationManager.AppSettings["TipoVentaFinanciamiento"]))
                    //    return RedirectToAction("Create", "Financiamientos", new { idVenta = tVenta.IdVenta });


                }

            }
            catch (Exception e) {
                return false;
            }


            return false;

        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<int> CantidadCuotas(string Monto,string Cuota, string Taza )
        {
            decimal saldo = Convert.ToDecimal( Monto);
            int cuota = Convert.ToInt32( Cuota);
            decimal taza = Convert.ToDecimal(Taza);
            int cantidad  = 0;
            decimal interes, amortizacion;
            if (ModelState.IsValid)
            {
                while (saldo>cuota) {
                    interes = saldo * (taza/100);
                    amortizacion = cuota - interes;
                    saldo = saldo - amortizacion;
                    cantidad++;
                }                
            }
           
            return cantidad+1;
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TVenta tVenta = await db.TVenta.FindAsync(id);
            db.TVenta.Remove(tVenta);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void CargarComboVehiculos(string placa)
        {
            var vehs = db.TVehiculo;
            var ventas = db.TVenta;
            var match = vehs.Join(ventas, x => x.Placa, y => y.Placa, (x, y) => new { Id = x.Placa });
            var vehiculos = vehs.Where(x => !match.Contains(new { Id = x.Placa }));


            //var vehiculos = db.TVehiculo;
            List<object> vehiculosList = new List<object>();
            foreach (var v in vehiculos)
                vehiculosList.Add(new
                {
                    Id = v.Placa,
                    Name = v.Placa + " - " + v.CMarcaVehiculo.Descripcion
                });
            if (placa == string.Empty)
            {

                ViewBag.Placa = new SelectList(vehiculosList, "Id", "Name");
            }
            else
            {
                ViewBag.Placa = new SelectList(vehiculosList, "Id", "Name", placa);
            }

        }

        protected void CargarComboClientes(int? idCliente)
        {          

            var clientes = db.TCliente;
            List<object> clientesList = new List<object>();
            foreach (var c in clientes)
                clientesList.Add(new
                {
                    Id = c.IdCliente,
                    Name = c.Identificacion + " - " + c.Nombre + " " + c.PrimerApellido + " " + c.SegundoApellido
                });

            if (idCliente == null)
            {

                ViewBag.IdCliente = new SelectList(clientesList, "Id", "Name");
            }
            else
            {
                ViewBag.IdCliente = new SelectList(clientesList, "Id", "Name", idCliente);
            }



        }

    }
}
