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
    [Authorize]
    public class PagosFinanciamientoController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: PagosFinanciamiento
        public ActionResult Index()
        {
            var tPagoFinanciamiento = db.TPagoFinanciamiento.Include(t => t.CTipoPago).Include(t => t.TFinanciamiento);
            return View(tPagoFinanciamiento.ToList());
        }

        // GET: PagosFinanciamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagoFinanciamiento tPagoFinanciamiento = db.TPagoFinanciamiento.Find(id);
            if (tPagoFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tPagoFinanciamiento);
        }

        // GET: PagosFinanciamiento/Create
        public ActionResult Create()
        {
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa");
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion");
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "IdFinanciamiento");
            return View();
        }

        // POST: PagosFinanciamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPagoFinan,IdVenta,IdTipoPago,Fecha,Monto,IdFinanciamiento")] TPagoFinanciamiento tPagoFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.TPagoFinanciamiento.Add(tPagoFinanciamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "IdFinanciamiento", tPagoFinanciamiento.IdFinanciamiento);
            return View(tPagoFinanciamiento);
        }

        // GET: PagosFinanciamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagoFinanciamiento tPagoFinanciamiento = db.TPagoFinanciamiento.Find(id);
            if (tPagoFinanciamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "IdFinanciamiento", tPagoFinanciamiento.IdFinanciamiento);
            return View(tPagoFinanciamiento);
        }

        // POST: PagosFinanciamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPagoFinan,IdVenta,IdTipoPago,Fecha,Monto,IdFinanciamiento")] TPagoFinanciamiento tPagoFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tPagoFinanciamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "IdFinanciamiento", tPagoFinanciamiento.IdFinanciamiento);
            return View(tPagoFinanciamiento);
        }

        // GET: PagosFinanciamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagoFinanciamiento tPagoFinanciamiento = db.TPagoFinanciamiento.Find(id);
            if (tPagoFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tPagoFinanciamiento);
        }

        // POST: PagosFinanciamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TPagoFinanciamiento tPagoFinanciamiento = db.TPagoFinanciamiento.Find(id);
            db.TPagoFinanciamiento.Remove(tPagoFinanciamiento);
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
