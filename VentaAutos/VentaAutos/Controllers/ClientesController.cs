using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            // return View(db.TCliente.ToList());
            return View(await db.TCliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TCliente tCliente = db.TCliente.Find(id);
            if (tCliente == null)
            {
                return HttpNotFound();
            }
            return View(tCliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Identificacion,Nombre,PrimerApellido,SegundoApellido,Direccion,Correo")] TCliente tCliente)
        {
            if (Request.Form["telefono"] != null)
            {

            }

                if (ModelState.IsValid)
            {
                db.TCliente.Add(tCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tCliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TCliente tCliente = db.TCliente.Find(id);
            if (tCliente == null)
            {
                return HttpNotFound();
            }
            return View(tCliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Identificacion,Nombre,PrimerApellido,SegundoApellido,Direccion,Correo")] TCliente tCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tCliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TCliente tCliente = db.TCliente.Find(id);
            if (tCliente == null)
            {
                return HttpNotFound();
            }
            return View(tCliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TCliente tCliente = db.TCliente.Find(id);
            db.TCliente.Remove(tCliente);
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
