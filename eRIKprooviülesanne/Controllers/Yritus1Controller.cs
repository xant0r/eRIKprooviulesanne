using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eRIKprooviülesanne.Models;

namespace eRIKprooviülesanne.Controllers
{
    public class Yritus1Controller : Controller
    {
        private YritusEntities1 db = new YritusEntities1();

        // GET: Yritus1
        public async Task<ActionResult> Index()
        {
            return View(await db.Yritus1.ToListAsync());
        }
        public async Task<ActionResult> NewIndex()
        {
            return View(await db.Yritus1.ToListAsync());
        }

        // GET: Yritus1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yritus1 yritus1 = await db.Yritus1.FindAsync(id);
            if (yritus1 == null)
            {
                return HttpNotFound();
            }
            return View(yritus1);
        }

        // GET: Yritus1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yritus1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Ürituse_nimi,Toimumisaeg,Koht,Lisainfo")] Yritus1 yritus1)
        {
            if (ModelState.IsValid)
            {
                db.Yritus1.Add(yritus1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(yritus1);
        }

        // GET: Yritus1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yritus1 yritus1 = await db.Yritus1.FindAsync(id);
            if (yritus1 == null)
            {
                return HttpNotFound();
            }
            return View(yritus1);
        }

        // POST: Yritus1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Ürituse_nimi,Toimumisaeg,Koht,Lisainfo")] Yritus1 yritus1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yritus1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(yritus1);
        }

        // GET: Yritus1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yritus1 yritus1 = await db.Yritus1.FindAsync(id);
            if (yritus1 == null)
            {
                return HttpNotFound();
            }
            return View(yritus1);
        }

        // POST: Yritus1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Yritus1 yritus1 = await db.Yritus1.FindAsync(id);
            db.Yritus1.Remove(yritus1);
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
