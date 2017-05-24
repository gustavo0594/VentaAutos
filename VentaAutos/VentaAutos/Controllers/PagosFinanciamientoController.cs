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
            var tPagoFinanciamiento = db.TPagoFinanciamiento.Include(t => t.CTipoPago).Include(t => t.TFinanciamiento);
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
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion");
            return View();
        }

        // POST: PagosFinanciamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPagoFinan,IdVenta,IdTipoPago,Fecha,Monto,IdFinanciamiento,Intereses")] TPagoFinanciamiento tPagoFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                TVenta venta = db.TVenta.Find(tPagoFinanciamiento.IdVenta);
                venta.Saldo -= (tPagoFinanciamiento.Monto).Value;
                db.TPagoFinanciamiento.Add(tPagoFinanciamiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion", tPagoFinanciamiento.IdFinanciamiento);
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
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion", tPagoFinanciamiento.IdFinanciamiento);
            return View(tPagoFinanciamiento);
        }

        // POST: PagosFinanciamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPagoFinan,IdVenta,IdTipoPago,Fecha,Monto,IdFinanciamiento,Intereses")] TPagoFinanciamiento tPagoFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tPagoFinanciamiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagoFinanciamiento.IdTipoPago);
            ViewBag.IdFinanciamiento = new SelectList(db.TFinanciamiento, "IdFinanciamiento", "Descripcion", tPagoFinanciamiento.IdFinanciamiento);
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

        [HttpPost, ActionName("GetMontoPago")]
        public JsonResult GetMontoPago(int ventaId)
        {
            TVenta tVenta = db.TVenta.Find(ventaId);
            TFinanciamiento financiamiento = tVenta.TFinanciamiento.First();
            if (financiamiento != null)
            {
                decimal monto =  tVenta.Saldo / financiamiento.Plazo;
                decimal intereses = (tVenta.Saldo * financiamiento.Interes) / 100;
                return Json(new TPagoFinanciamiento { Monto = monto, Intereses = intereses});
            }
            return Json(0);
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
