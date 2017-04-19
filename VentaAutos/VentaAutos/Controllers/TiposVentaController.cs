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
    public class TiposVentaController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: TiposVenta
        public ActionResult Index()
        {
            return View(db.CTipoVenta.ToList());
        }

        // GET: TiposVenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoVenta cTipoVenta = db.CTipoVenta.Find(id);
            if (cTipoVenta == null)
            {
                return HttpNotFound();
            }
            return View(cTipoVenta);
        }

        // GET: TiposVenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposVenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoVenta,Descripcion")] CTipoVenta cTipoVenta)
        {
            if (ModelState.IsValid)
            {
                db.CTipoVenta.Add(cTipoVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTipoVenta);
        }

        // GET: TiposVenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoVenta cTipoVenta = db.CTipoVenta.Find(id);
            if (cTipoVenta == null)
            {
                return HttpNotFound();
            }
            return View(cTipoVenta);
        }

        // POST: TiposVenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoVenta,Descripcion")] CTipoVenta cTipoVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTipoVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTipoVenta);
        }

        // GET: TiposVenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoVenta cTipoVenta = db.CTipoVenta.Find(id);
            if (cTipoVenta == null)
            {
                return HttpNotFound();
            }
            return View(cTipoVenta);
        }

        // POST: TiposVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTipoVenta cTipoVenta = db.CTipoVenta.Find(id);
            db.CTipoVenta.Remove(cTipoVenta);
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
