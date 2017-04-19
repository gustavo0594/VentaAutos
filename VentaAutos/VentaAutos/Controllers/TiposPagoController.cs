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
    public class TiposPagoController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: TiposPago
        public ActionResult Index()
        {
            return View(db.CTipoPago.ToList());
        }

        // GET: TiposPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoPago cTipoPago = db.CTipoPago.Find(id);
            if (cTipoPago == null)
            {
                return HttpNotFound();
            }
            return View(cTipoPago);
        }

        // GET: TiposPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPago,Descripcion")] CTipoPago cTipoPago)
        {
            if (ModelState.IsValid)
            {
                db.CTipoPago.Add(cTipoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTipoPago);
        }

        // GET: TiposPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoPago cTipoPago = db.CTipoPago.Find(id);
            if (cTipoPago == null)
            {
                return HttpNotFound();
            }
            return View(cTipoPago);
        }

        // POST: TiposPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPago,Descripcion")] CTipoPago cTipoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTipoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTipoPago);
        }

        // GET: TiposPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoPago cTipoPago = db.CTipoPago.Find(id);
            if (cTipoPago == null)
            {
                return HttpNotFound();
            }
            return View(cTipoPago);
        }

        // POST: TiposPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTipoPago cTipoPago = db.CTipoPago.Find(id);
            db.CTipoPago.Remove(cTipoPago);
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
