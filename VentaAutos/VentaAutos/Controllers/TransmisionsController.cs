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
    public class TransmisionsController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Transmisions
        public async Task<ActionResult> Index()
        {
            return View(await db.CTransmision.ToListAsync());
        }

        // GET: Transmisions/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTransmision cTransmision = await db.CTransmision.FindAsync(id);
            if (cTransmision == null)
            {
                return HttpNotFound();
            }
            return View(cTransmision);
        }

        // GET: Transmisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transmisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTransmision,Descripcion")] CTransmision cTransmision)
        {
            if (ModelState.IsValid)
            {
                db.CTransmision.Add(cTransmision);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cTransmision);
        }

        // GET: Transmisions/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTransmision cTransmision = await db.CTransmision.FindAsync(id);
            if (cTransmision == null)
            {
                return HttpNotFound();
            }
            return View(cTransmision);
        }

        // POST: Transmisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTransmision,Descripcion")] CTransmision cTransmision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTransmision).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cTransmision);
        }

        // GET: Transmisions/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTransmision cTransmision = await db.CTransmision.FindAsync(id);
            if (cTransmision == null)
            {
                return HttpNotFound();
            }
            return View(cTransmision);
        }

        // POST: Transmisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            CTransmision cTransmision = await db.CTransmision.FindAsync(id);
            db.CTransmision.Remove(cTransmision);
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
