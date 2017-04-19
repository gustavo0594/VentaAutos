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
    public class TiposVehiculoController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: TiposVehiculo
        public ActionResult Index()
        {
            return View(db.CTipoVehiculo.ToList());
        }

        // GET: TiposVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoVehiculo cTipoVehiculo = db.CTipoVehiculo.Find(id);
            if (cTipoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cTipoVehiculo);
        }

        // GET: TiposVehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposVehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipo,Descripcion")] CTipoVehiculo cTipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.CTipoVehiculo.Add(cTipoVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTipoVehiculo);
        }

        // GET: TiposVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoVehiculo cTipoVehiculo = db.CTipoVehiculo.Find(id);
            if (cTipoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cTipoVehiculo);
        }

        // POST: TiposVehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipo,Descripcion")] CTipoVehiculo cTipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTipoVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTipoVehiculo);
        }

        // GET: TiposVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoVehiculo cTipoVehiculo = db.CTipoVehiculo.Find(id);
            if (cTipoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cTipoVehiculo);
        }

        // POST: TiposVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTipoVehiculo cTipoVehiculo = db.CTipoVehiculo.Find(id);
            db.CTipoVehiculo.Remove(cTipoVehiculo);
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
