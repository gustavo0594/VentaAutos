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
    public class EstadosArticulosController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: EstadosArticulos
        public ActionResult Index()
        {
            return View(db.CEstadoArticulo.ToList());
        }

        // GET: EstadosArticulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CEstadoArticulo cEstadoArticulo = db.CEstadoArticulo.Find(id);
            if (cEstadoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(cEstadoArticulo);
        }

        // GET: EstadosArticulos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadosArticulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstado,Descripcion")] CEstadoArticulo cEstadoArticulo)
        {
            if (ModelState.IsValid)
            {
                db.CEstadoArticulo.Add(cEstadoArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cEstadoArticulo);
        }

        // GET: EstadosArticulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CEstadoArticulo cEstadoArticulo = db.CEstadoArticulo.Find(id);
            if (cEstadoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(cEstadoArticulo);
        }

        // POST: EstadosArticulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstado,Descripcion")] CEstadoArticulo cEstadoArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cEstadoArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cEstadoArticulo);
        }

        // GET: EstadosArticulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CEstadoArticulo cEstadoArticulo = db.CEstadoArticulo.Find(id);
            if (cEstadoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(cEstadoArticulo);
        }

        // POST: EstadosArticulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CEstadoArticulo cEstadoArticulo = db.CEstadoArticulo.Find(id);
            db.CEstadoArticulo.Remove(cEstadoArticulo);
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
