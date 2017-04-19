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
    public class CMarcasVehiculoController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: CMarcasVehiculo
        public ActionResult Index()
        {
            return View(db.CMarcaVehiculo.ToList());
        }

        // GET: CMarcasVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMarcaVehiculo cMarcaVehiculo = db.CMarcaVehiculo.Find(id);
            if (cMarcaVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cMarcaVehiculo);
        }

        // GET: CMarcasVehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMarcasVehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMarca,Descripcion")] CMarcaVehiculo cMarcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.CMarcaVehiculo.Add(cMarcaVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMarcaVehiculo);
        }

        // GET: CMarcasVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMarcaVehiculo cMarcaVehiculo = db.CMarcaVehiculo.Find(id);
            if (cMarcaVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cMarcaVehiculo);
        }

        // POST: CMarcasVehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMarca,Descripcion")] CMarcaVehiculo cMarcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMarcaVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMarcaVehiculo);
        }

        // GET: CMarcasVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMarcaVehiculo cMarcaVehiculo = db.CMarcaVehiculo.Find(id);
            if (cMarcaVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cMarcaVehiculo);
        }

        // POST: CMarcasVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMarcaVehiculo cMarcaVehiculo = db.CMarcaVehiculo.Find(id);
            db.CMarcaVehiculo.Remove(cMarcaVehiculo);
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
