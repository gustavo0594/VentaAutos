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
    public class TFinanciamientosController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: TFinanciamientos
        public ActionResult Index()
        {
            var tFinanciamiento = db.TFinanciamiento.Include(t => t.CPeriodoPago);
            return View(tFinanciamiento.ToList());
        }

        // GET: TFinanciamientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TFinanciamiento tFinanciamiento = db.TFinanciamiento.Find(id);
            if (tFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tFinanciamiento);
        }

        // GET: TFinanciamientos/Create
        public ActionResult Create()
        {
            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion");
            return View();
        }

        // POST: TFinanciamientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFinanciamiento,Interes,Plazo,IdPeriodoPago,Descripcion")] TFinanciamiento tFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.TFinanciamiento.Add(tFinanciamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion", tFinanciamiento.IdPeriodoPago);
            return View(tFinanciamiento);
        }

        // GET: TFinanciamientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TFinanciamiento tFinanciamiento = db.TFinanciamiento.Find(id);
            if (tFinanciamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion", tFinanciamiento.IdPeriodoPago);
            return View(tFinanciamiento);
        }

        // POST: TFinanciamientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFinanciamiento,Interes,Plazo,IdPeriodoPago,Descripcion")] TFinanciamiento tFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tFinanciamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion", tFinanciamiento.IdPeriodoPago);
            return View(tFinanciamiento);
        }

        // GET: TFinanciamientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TFinanciamiento tFinanciamiento = db.TFinanciamiento.Find(id);
            if (tFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tFinanciamiento);
        }

        // POST: TFinanciamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TFinanciamiento tFinanciamiento = db.TFinanciamiento.Find(id);
            db.TFinanciamiento.Remove(tFinanciamiento);
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
