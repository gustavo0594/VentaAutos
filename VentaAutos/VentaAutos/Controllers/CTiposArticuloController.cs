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
    public class CTiposArticuloController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: CTiposArticulo
        public ActionResult Index()
        {
            return View(db.CTipoArticulo.ToList());
        }

        // GET: CTiposArticulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoArticulo cTipoArticulo = db.CTipoArticulo.Find(id);
            if (cTipoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(cTipoArticulo);
        }

        // GET: CTiposArticulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTiposArticulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoArticulo,Descripcion")] CTipoArticulo cTipoArticulo)
        {
            if (ModelState.IsValid)
            {
                db.CTipoArticulo.Add(cTipoArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTipoArticulo);
        }

        // GET: CTiposArticulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoArticulo cTipoArticulo = db.CTipoArticulo.Find(id);
            if (cTipoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(cTipoArticulo);
        }

        // POST: CTiposArticulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoArticulo,Descripcion")] CTipoArticulo cTipoArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTipoArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTipoArticulo);
        }

        // GET: CTiposArticulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTipoArticulo cTipoArticulo = db.CTipoArticulo.Find(id);
            if (cTipoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(cTipoArticulo);
        }

        // POST: CTiposArticulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTipoArticulo cTipoArticulo = db.CTipoArticulo.Find(id);
            db.CTipoArticulo.Remove(cTipoArticulo);
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
