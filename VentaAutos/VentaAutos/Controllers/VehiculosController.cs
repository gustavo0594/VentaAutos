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

namespace VentaAutos.Controllers
{
    public class VehiculosController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Vehiculos
        public async Task<ActionResult> Index()
        {

            var vehs = db.TVehiculo;
            var ventas = db.TVenta;

            var match = vehs.Join(ventas, x => x.Placa, y => y.Placa, (x, y) => new { Id = x.Placa });
            var vehiculos = vehs.Where(x => !match.Contains(new { Id = x.Placa }));
                                  
            //List<object> vehiculosList = new List<object>();
            //foreach (var v in vehiculos)
            //    vehiculosList.Add(new
            //    {
            //        Id = v.Placa,
            //        Name = v.Placa + " - " + v.CMarcaVehiculo.Descripcion
            //    });
           
            //var tVehiculo = db.TVehiculo.Include(t => t.CEstadoArticulo).Include(t => t.CMarcaVehiculo).Include(t => t.CTipoArticulo).Include(t => t.CTipoVehiculo).Include(t => t.CTransmision).Include(t => t.TCliente);

            return View(await vehiculos.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVehiculo tVehiculo = await db.TVehiculo.FindAsync(id);
            if (tVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tVehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion");
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion");
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion");
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion");
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion");
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");
            CargarComboClientes(null);
            return View();
        }

        // POST: Vehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Placa,IdMarca,Anio,Estilo,IdTransmision,Modelo,NumPuertas,IdTipoVehiculo,Valor,IdTipoArticulo,IdEstado,Monto,FechaIngreso,IdCliente")] TVehiculo tVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.TVehiculo.Add(tVehiculo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion", tVehiculo.IdEstado);
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion", tVehiculo.IdMarca);
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion", tVehiculo.IdTipoArticulo);
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion", tVehiculo.IdTipoVehiculo);
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion", tVehiculo.IdTransmision);
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVehiculo.IdCliente);
            CargarComboClientes(tVehiculo.IdCliente);
            return View(tVehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVehiculo tVehiculo = await db.TVehiculo.FindAsync(id);
            if (tVehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion", tVehiculo.IdEstado);
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion", tVehiculo.IdMarca);
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion", tVehiculo.IdTipoArticulo);
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion", tVehiculo.IdTipoVehiculo);
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion", tVehiculo.IdTransmision);
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVehiculo.IdCliente);
            CargarComboClientes(tVehiculo.IdCliente);
            return View(tVehiculo);
        }

        // POST: Vehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Placa,IdMarca,Anio,Estilo,IdTransmision,Modelo,NumPuertas,IdTipoVehiculo,Valor,IdTipoArticulo,IdEstado,Monto,FechaIngreso,IdCliente")] TVehiculo tVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVehiculo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion", tVehiculo.IdEstado);
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion", tVehiculo.IdMarca);
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion", tVehiculo.IdTipoArticulo);
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion", tVehiculo.IdTipoVehiculo);
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion", tVehiculo.IdTransmision);
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVehiculo.IdCliente);
            CargarComboClientes(tVehiculo.IdCliente);
            return View(tVehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVehiculo tVehiculo = await db.TVehiculo.FindAsync(id);
            if (tVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tVehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            TVehiculo tVehiculo = await db.TVehiculo.FindAsync(id);
            db.TVehiculo.Remove(tVehiculo);
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


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> GetVehiculo( String placa)
        public async Task<Boolean> GetVehiculo(string placa)
        {
            if (placa == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return false;
            }
           // TVehiculo tVehiculo = await db.VehiculosDisponibles().FindAsync(placa);
            var tVehiculo = db.VehiculosDisponibles().Where(a => a.Placa.Equals(placa)).FirstOrDefault();



            if (tVehiculo == null)
            {
                // return HttpNotFound();
                return false;
            }
            return true;

        }


    }
}
