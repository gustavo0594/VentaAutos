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
    public class FinanciamientosController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Financiamientos
        public async Task<ActionResult> Index()
        {
            var tFinanciamiento = db.TFinanciamiento.Include(t => t.CPeriodoPago).Include(t => t.TVenta);
            return View(await tFinanciamiento.ToListAsync());
        }

        // GET: Financiamientos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TFinanciamiento tFinanciamiento = await db.TFinanciamiento.FindAsync(id);
            if (tFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tFinanciamiento);
        }

        // GET: Financiamientos/Create
        public ActionResult Create()
        {
            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion");
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa");
            return View();
        }

        // POST: Financiamientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFinanciamiento,Interes,Plazo,IdPeriodoPago,Descripcion,IdVenta")] TFinanciamiento tFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.TFinanciamiento.Add(tFinanciamiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion", tFinanciamiento.IdPeriodoPago);
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tFinanciamiento.IdVenta);
            return View(tFinanciamiento);
        }

        // GET: Financiamientos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TFinanciamiento tFinanciamiento = await db.TFinanciamiento.FindAsync(id);
            if (tFinanciamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion", tFinanciamiento.IdPeriodoPago);
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tFinanciamiento.IdVenta);
            return View(tFinanciamiento);
        }

        // POST: Financiamientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFinanciamiento,Interes,Plazo,IdPeriodoPago,Descripcion,IdVenta")] TFinanciamiento tFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tFinanciamiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPeriodoPago = new SelectList(db.CPeriodoPago, "IdPeriodoPago", "Descripcion", tFinanciamiento.IdPeriodoPago);
            ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tFinanciamiento.IdVenta);
            return View(tFinanciamiento);
        }

        // GET: Financiamientos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TFinanciamiento tFinanciamiento = await db.TFinanciamiento.FindAsync(id);
            if (tFinanciamiento == null)
            {
                return HttpNotFound();
            }
            return View(tFinanciamiento);
        }

        // POST: Financiamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TFinanciamiento tFinanciamiento = await db.TFinanciamiento.FindAsync(id);
            db.TFinanciamiento.Remove(tFinanciamiento);
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
