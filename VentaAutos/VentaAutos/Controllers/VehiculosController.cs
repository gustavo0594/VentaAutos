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
    public class VehiculosController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Vehiculos
        public ActionResult Index()
        {
            var tVehiculo = db.TVehiculo.Include(t => t.CEstadoArticulo).Include(t => t.CMarcaVehiculo).Include(t => t.CTipoArticulo).Include(t => t.CTipoVehiculo).Include(t => t.CTransmision);
            return View(tVehiculo.ToList());
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVehiculo tVehiculo = db.TVehiculo.Find(id);
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
            return View();
        }

        // POST: Vehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Placa,IdMarca,Anio,Estilo,IdTransmision,Modelo,NumPuertas,IdTipoVehiculo,Valor,IdTipoArticulo,IdEstado")] TVehiculo tVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.TVehiculo.Add(tVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion", tVehiculo.IdEstado);
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion", tVehiculo.IdMarca);
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion", tVehiculo.IdTipoArticulo);
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion", tVehiculo.IdTipoVehiculo);
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion", tVehiculo.IdTransmision);
            return View(tVehiculo);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVehiculo tVehiculo = db.TVehiculo.Find(id);
            if (tVehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion", tVehiculo.IdEstado);
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion", tVehiculo.IdMarca);
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion", tVehiculo.IdTipoArticulo);
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion", tVehiculo.IdTipoVehiculo);
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion", tVehiculo.IdTransmision);
            return View(tVehiculo);
        }

        // POST: Vehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Placa,IdMarca,Anio,Estilo,IdTransmision,Modelo,NumPuertas,IdTipoVehiculo,Valor,IdTipoArticulo,IdEstado")] TVehiculo tVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.CEstadoArticulo, "IdEstado", "Descripcion", tVehiculo.IdEstado);
            ViewBag.IdMarca = new SelectList(db.CMarcaVehiculo, "IdMarca", "Descripcion", tVehiculo.IdMarca);
            ViewBag.IdTipoArticulo = new SelectList(db.CTipoArticulo, "IdTipoArticulo", "Descripcion", tVehiculo.IdTipoArticulo);
            ViewBag.IdTipoVehiculo = new SelectList(db.CTipoVehiculo, "IdTipo", "Descripcion", tVehiculo.IdTipoVehiculo);
            ViewBag.IdTransmision = new SelectList(db.CTransmision, "IdTransmision", "Descripcion", tVehiculo.IdTransmision);
            return View(tVehiculo);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVehiculo tVehiculo = db.TVehiculo.Find(id);
            if (tVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tVehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TVehiculo tVehiculo = db.TVehiculo.Find(id);
            db.TVehiculo.Remove(tVehiculo);
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
    }
}
