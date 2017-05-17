using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
    public class VentasController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var tVenta = db.TVenta.Include(t => t.CTipoVenta).Include(t => t.TCliente).Include(t => t.TFinanciamiento).Include(t => t.TVehiculo);
            return View(tVenta.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = db.TVenta.Find(id);
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
           
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion");
            //ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo");
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");

            CargarComboClientes(null);
            CargarComboVehiculos(string.Empty);

            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,Monto,Fecha,IdTipoVenta,IdCliente,Saldo,Placa,IdFinanciamiento")] TVenta tVenta)
        {
            if (ModelState.IsValid)
            {
                db.TVenta.Add(tVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion", tVenta.IdFinanciamiento);
            ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
            return View(tVenta);
        }

        // GET: Ventas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = db.TVenta.Find(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
           
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion", tVenta.IdFinanciamiento);
            //ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            CargarComboClientes(tVenta.IdCliente);
            CargarComboVehiculos(tVenta.Placa);
            return View(tVenta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,Monto,Fecha,IdTipoVenta,IdCliente,Saldo,Placa,IdFinanciamiento")] TVenta tVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion", tVenta.IdFinanciamiento);
            ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tVenta.Placa);
            return View(tVenta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = db.TVenta.Find(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            return View(tVenta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVenta tVenta = db.TVenta.Find(id);
            db.TVenta.Remove(tVenta);
            db.SaveChanges();
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
            var vehiculos = db.TVehiculo;
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
