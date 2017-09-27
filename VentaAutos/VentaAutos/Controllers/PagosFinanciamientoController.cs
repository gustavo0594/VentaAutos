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
    public class PagosFinanciamientoController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: PagosFinanciamiento
        public async Task<ActionResult> Index()
        {
            var tPagoFinanciamiento = db.TPagoFinanciamiento.Include(t => t.CTipoPago).Include(t => t.TVenta);
            return View(await tPagoFinanciamiento.ToListAsync());
        }

        // GET: PagosFinanciamiento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagoFinanciamiento tPagoFinanciamiento = await db.TPagoFinanciamiento.FindAsync(id);
            if (tPagoFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tPagoFinanciamiento);
        }

        // GET: PagosFinanciamiento/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion");
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa");
            return View();
        }

        // POST: PagosFinanciamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPagoFinan,IdVenta,IdTipoPago,Fecha,Monto,Intereses")] TPagoFinanciamiento tPagoFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.TPagoFinanciamiento.Add(tPagoFinanciamiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tPagoFinanciamiento.IdVenta);
            return View(tPagoFinanciamiento);
        }

        // GET: PagosFinanciamiento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagoFinanciamiento tPagoFinanciamiento = await db.TPagoFinanciamiento.FindAsync(id);
            if (tPagoFinanciamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tPagoFinanciamiento.IdVenta);
            return View(tPagoFinanciamiento);
        }

        // POST: PagosFinanciamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPagoFinan,IdVenta,IdTipoPago,Fecha,Monto,Intereses")] TPagoFinanciamiento tPagoFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tPagoFinanciamiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tPagoFinanciamiento.IdVenta);
            return View(tPagoFinanciamiento);
        }

        // GET: PagosFinanciamiento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagoFinanciamiento tPagoFinanciamiento = await db.TPagoFinanciamiento.FindAsync(id);
            if (tPagoFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tPagoFinanciamiento);
        }

        // POST: PagosFinanciamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TPagoFinanciamiento tPagoFinanciamiento = await db.TPagoFinanciamiento.FindAsync(id);
            db.TPagoFinanciamiento.Remove(tPagoFinanciamiento);
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
