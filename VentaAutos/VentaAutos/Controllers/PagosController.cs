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
    public class PagosController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: Pagos
        public async Task<ActionResult> Index()
        {
            var tPagos = db.TPagos.Include(t => t.CTipoPago).Include(t => t.TVenta);
            return View(await tPagos.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagos tPagos = await db.TPagos.FindAsync(id);
            if (tPagos == null)
            {
                return HttpNotFound();
            }
            return View(tPagos);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion");
            //ViewBag.IdVenta = new SelectList(db.TVenta.Where(v => v.IdTipoVenta ==2 ) , "IdVenta", "Placa");//tipo venta == 2 (finaniamiento )
            CargarComboVentas(null);
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPago,IdVenta,Fecha,PeriodoCancelado,Saldo,IdTipoPago,Monto")] TPagos tPagos)
        {
            if (ModelState.IsValid)
            {
                db.TPagos.Add(tPagos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagos.IdTipoPago);
            //ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tPagos.IdVenta);
            CargarComboVentas(tPagos.IdVenta);
            return View(tPagos);
        }

        // GET: Pagos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagos tPagos = await db.TPagos.FindAsync(id);
            if (tPagos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagos.IdTipoPago);
            //ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tPagos.IdVenta);
            CargarComboVentas(tPagos.IdVenta);
            return View(tPagos);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPago,IdVenta,Fecha,PeriodoCancelado,Saldo,IdTipoPago,Monto")] TPagos tPagos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tPagos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPago = new SelectList(db.CTipoPago, "IdTipoPago", "Descripcion", tPagos.IdTipoPago);
            //ViewBag.IdVenta = new SelectList(db.TVenta, "IdVenta", "Placa", tPagos.IdVenta);
            CargarComboVentas(tPagos.IdVenta);
            return View(tPagos);
        }

        // GET: Pagos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPagos tPagos = await db.TPagos.FindAsync(id);
            if (tPagos == null)
            {
                return HttpNotFound();
            }
            return View(tPagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TPagos tPagos = await db.TPagos.FindAsync(id);
            db.TPagos.Remove(tPagos);
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

        protected void CargarComboVentas(int? idVenta)
        {
           // ViewBag.IdVenta = new SelectList(db.TVenta.Where(v => v.IdTipoVenta == 2), "IdVenta", "Placa");//tipo venta == 2 (finaniamiento )

            var ventas = db.TVenta.Where(v => v.IdTipoVenta == 2); //tipo venta == 2 (finaniamiento )
            List<object> ventasList = new List<object>();
            foreach (var v in ventas)
                ventasList.Add(new
                {
                    Id = v.IdVenta,
                    Name = v.TCliente.Nombre  + " " + v.TCliente.PrimerApellido + " " + v.TCliente.SegundoApellido + " - " + v.Placa
                });

            if (idVenta == null)
            {

                ViewBag.IdVenta = new SelectList(ventasList, "Id", "Name");
            }
            else
            {
                ViewBag.IdVenta = new SelectList(ventasList, "Id", "Name", idVenta);
            }



        }


    }
}
