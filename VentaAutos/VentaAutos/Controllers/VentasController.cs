using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
    public class VentasController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Ventas
        public async Task<ActionResult> Index()
        {
            var tVenta = db.TVenta.Include(t => t.CTipoVenta).Include(t => t.TCliente);
            return View(await tVenta.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = await db.TVenta.FindAsync(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            return View(tVenta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion");
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdVenta,Monto,Fecha,IdTipoVenta,IdCliente,Saldo")] TVenta tVenta)
        {
            if (ModelState.IsValid)
            {
                db.TVenta.Add(tVenta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            return View(tVenta);
        }

        // GET: Ventas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = await db.TVenta.FindAsync(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            return View(tVenta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdVenta,Monto,Fecha,IdTipoVenta,IdCliente,Saldo")] TVenta tVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVenta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoVenta = new SelectList(db.CTipoVenta, "IdTipoVenta", "Descripcion", tVenta.IdTipoVenta);
            ViewBag.IdCliente = new SelectList(db.TCliente, "IdCliente", "Identificacion", tVenta.IdCliente);
            return View(tVenta);
        }

        // GET: Ventas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVenta tVenta = await db.TVenta.FindAsync(id);
            if (tVenta == null)
            {
                return HttpNotFound();
            }
            return View(tVenta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TVenta tVenta = await db.TVenta.FindAsync(id);
            db.TVenta.Remove(tVenta);
            await db.SaveChangesAsync();
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
