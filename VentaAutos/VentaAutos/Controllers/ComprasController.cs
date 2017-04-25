using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
    public class ComprasController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Compras
        public ActionResult Index()
        {
            var tCompra = db.TCompra.Include(t => t.TCliente).Include(t => t.TVehiculo);
            return View(tCompra.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? idCliente, string placa)
        {
            if (idCliente == null && placa == String.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TCompra tCompra = db.TCompra.Find(idCliente, placa);
            if (tCompra == null)
            {
                return HttpNotFound();
            }
            return View(tCompra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");
            //ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Placa");


            CargarComboClientes();
            CargarComboVehiculos();


            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Placa,Monto,Fecha")] TCompra tCompra)
        {
            if (ModelState.IsValid)
            {
                db.TCompra.Add(tCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tCompra.IdCliente);
            ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tCompra.Placa);
            return View(tCompra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? idCliente, string placa)    
        {
            if (idCliente == null && placa== String.Empty )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TCompra tCompra = db.TCompra.Find(idCliente, placa);
            if (tCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tCompra.IdCliente);
            ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tCompra.Placa);
            return View(tCompra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Placa,Monto,Fecha")] TCompra tCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tCompra.IdCliente);
            ViewBag.Placa = new SelectList(db.TVehiculo, "Placa", "Estilo", tCompra.Placa);
            return View(tCompra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? idCliente, string placa)
        {
            if (idCliente == null && placa == String.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TCompra tCompra = db.TCompra.Find(idCliente, placa);
            if (tCompra == null)
            {
                return HttpNotFound();
            }
            return View(tCompra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idCliente, string placa)
        {
            TCompra tCompra = db.TCompra.Find(idCliente, placa);
            db.TCompra.Remove(tCompra);
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

        protected void CargarComboVehiculos()
        {
            var vehiculos = db.TVehiculo;
            List<object> vehiculosList = new List<object>();
            foreach (var v in vehiculos)
                vehiculosList.Add(new
                {
                    Id = v.Placa,
                    Name = v.Placa + " - " + v.CMarcaVehiculo.Descripcion
                });
            ViewBag.Placa = new SelectList(vehiculosList, "Id", "Name");

        }

        protected void CargarComboClientes()
        {
            var clientes = db.TCliente;
            List<object> clientesList = new List<object>();
            foreach (var c in clientes)
                clientesList.Add(new
                {
                    Id = c.IdCliente,
                    Name = c.Identificacion + " - " + c.Nombre + " " + c.PrimerApellido + " " + c.SegundoApellido
                });
            ViewBag.IdCliente = new SelectList(clientesList, "Id", "Name");

        }

    }
}
