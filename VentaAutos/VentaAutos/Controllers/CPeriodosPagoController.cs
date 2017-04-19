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
    public class CPeriodosPagoController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: CPeriodosPago
        public ActionResult Index()
        {
            return View(db.CPeriodoPago.ToList());
        }

        // GET: CPeriodosPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPeriodoPago cPeriodoPago = db.CPeriodoPago.Find(id);
            if (cPeriodoPago == null)
            {
                return HttpNotFound();
            }
            return View(cPeriodoPago);
        }

        // GET: CPeriodosPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CPeriodosPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPeriodoPago,Descripcion")] CPeriodoPago cPeriodoPago)
        {
            if (ModelState.IsValid)
            {
                db.CPeriodoPago.Add(cPeriodoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cPeriodoPago);
        }

        // GET: CPeriodosPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPeriodoPago cPeriodoPago = db.CPeriodoPago.Find(id);
            if (cPeriodoPago == null)
            {
                return HttpNotFound();
            }
            return View(cPeriodoPago);
        }

        // POST: CPeriodosPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPeriodoPago,Descripcion")] CPeriodoPago cPeriodoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cPeriodoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cPeriodoPago);
        }

        // GET: CPeriodosPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPeriodoPago cPeriodoPago = db.CPeriodoPago.Find(id);
            if (cPeriodoPago == null)
            {
                return HttpNotFound();
            }
            return View(cPeriodoPago);
        }

        // POST: CPeriodosPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPeriodoPago cPeriodoPago = db.CPeriodoPago.Find(id);
            db.CPeriodoPago.Remove(cPeriodoPago);
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
