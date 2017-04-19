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
    public class TelefonosClienteController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: TelefonosCliente
        public async Task<ActionResult> Index(int? IdCliente)
        {
            //var tTelefonoCliente = db.TTelefonoCliente.Include(t => t.TCliente);
            //return View(tTelefonoCliente.ToList());
            if (IdCliente == null)
            {

                var telefono = db.TTelefonoCliente.Include(t => t.TCliente);
                return View(await telefono.ToListAsync());
            }
            else
            {
                var telefono = db.TTelefonoCliente.Where(t => t.TCliente.IdCliente == IdCliente);
                ViewBag.IdCliente = IdCliente;
                return View(await telefono.ToListAsync());
            }
        }

        // GET: TelefonosCliente/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTelefonoCliente tTelefonoCliente = db.TTelefonoCliente.Find(id);
            if (tTelefonoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tTelefonoCliente);
        }

        // GET: TelefonosCliente/Create
        public async Task<ActionResult> Create(int? idCliente)
        {
            //string a = correo;
            //ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");
            //return View();

            if (idCliente == null)
            {
                ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");
                return View();
            }
            else
            {
                TCliente cliente = await db.TCliente.FindAsync(idCliente);
                TTelefonoCliente telefono = new TTelefonoCliente();
                telefono.TCliente = cliente;
                telefono.TCliente.IdCliente = cliente.IdCliente;

                ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", idCliente);
                ViewBag.IdClienteInt =  idCliente;
                return View(telefono);

            }
        }

        // POST: TelefonosCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTelefono,Descripcion,IdCliente")] TTelefonoCliente tTelefonoCliente)
        {

            if (ModelState.IsValid)
            {
                db.TTelefonoCliente.Add(tTelefonoCliente);
                await db.SaveChangesAsync();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", new { IdCliente = tTelefonoCliente.IdCliente });
            }

            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tTelefonoCliente.IdCliente);
            return View(tTelefonoCliente);


        }

        // GET: TelefonosCliente/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTelefonoCliente tTelefonoCliente = db.TTelefonoCliente.Find(id);
            if (tTelefonoCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tTelefonoCliente.IdCliente);
            ViewBag.IdClienteInt =  tTelefonoCliente.IdCliente;
            return View(tTelefonoCliente);
        }

        // POST: TelefonosCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTelefono,Descripcion,IdCliente")] TTelefonoCliente tTelefonoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tTelefonoCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { IdCliente = tTelefonoCliente.IdCliente });
                //return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tTelefonoCliente.IdCliente);
            return View(tTelefonoCliente);
        }

        // GET: TelefonosCliente/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTelefonoCliente tTelefonoCliente = db.TTelefonoCliente.Find(id);
            if (tTelefonoCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClienteInt = tTelefonoCliente.IdCliente;
            return View(tTelefonoCliente);
        }

        // POST: TelefonosCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TTelefonoCliente tTelefonoCliente = db.TTelefonoCliente.Find(id);
            db.TTelefonoCliente.Remove(tTelefonoCliente);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Index", new { IdCliente = tTelefonoCliente.IdCliente });
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
