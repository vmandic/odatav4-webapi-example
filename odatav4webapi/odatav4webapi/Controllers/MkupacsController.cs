using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using odatav4webapi.Models;

namespace odatav4webapi.Controllers
{
    public class MkupacsController : Controller
    {
        private AWEntities db = new AWEntities();

        // GET: Mkupacs
        public async Task<ActionResult> Index()
        {
            var kupacs = db.Kupacs.Include(k => k.Grad);
            return View(await kupacs.ToListAsync());
        }

        // GET: Mkupacs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = await db.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // GET: Mkupacs/Create
        public ActionResult Create()
        {
            ViewBag.GradID = new SelectList(db.Grads, "IDGrad", "Naziv");
            return View();
        }

        // POST: Mkupacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDKupac,Ime,Prezime,Email,Telefon,GradID")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                db.Kupacs.Add(kupac);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GradID = new SelectList(db.Grads, "IDGrad", "Naziv", kupac.GradID);
            return View(kupac);
        }

        // GET: Mkupacs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = await db.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradID = new SelectList(db.Grads, "IDGrad", "Naziv", kupac.GradID);
            return View(kupac);
        }

        // POST: Mkupacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDKupac,Ime,Prezime,Email,Telefon,GradID")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupac).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GradID = new SelectList(db.Grads, "IDGrad", "Naziv", kupac.GradID);
            return View(kupac);
        }

        // GET: Mkupacs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = await db.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // POST: Mkupacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kupac kupac = await db.Kupacs.FindAsync(id);
            db.Kupacs.Remove(kupac);
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
