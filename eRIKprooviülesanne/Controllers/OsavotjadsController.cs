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
using eRIKprooviülesanne.ViewModels;

namespace eRIKprooviülesanne.Controllers
{
    public class OsavotjadsController : Controller
    {
        private YritusEntities1 db = new YritusEntities1();

        

        // GET: Osavotjads
        public async Task<ActionResult> Index()
        {
            var osavotjads = db.Osavotjads.Include(o => o.Yritus1);
            return View(await osavotjads.ToListAsync());
        }
        public async Task<ActionResult> View1()
        {
            var x = from o in db.Osavotjads join o2 
                            in db.Yritus1 on o.ID equals o2.ID
                            where o.ID.Equals(o2.ID) select new ViewModelVM { Osavotjad = o, Yritus1 = o2 };
            return View(x);
        }

        // GET: Osavotjads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osavotjad osavotjad = await db.Osavotjads.FindAsync(id);
            if (osavotjad == null)
            {
                return HttpNotFound();
            }
            return View(osavotjad);
        }

        // GET: Osavotjads/Create
        public ActionResult Create()
        {
            ViewBag.Yritus_ID = new SelectList(db.Yritus1, "ID", "Ürituse_nimi");
            return View();
        }

        // POST: Osavotjads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Eesnimi,Perenimi,Isikukood,Makskmisviis,Lisainfo,Yritus_ID")] Osavotjad osavotjad)
        {
            if (ModelState.IsValid)
            {
                db.Osavotjads.Add(osavotjad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Yritus_ID = new SelectList(db.Yritus1, "ID", "Ürituse_nimi", osavotjad.Yritus_ID);
            return View(osavotjad);
        }

        // GET: Osavotjads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osavotjad osavotjad = await db.Osavotjads.FindAsync(id);
            if (osavotjad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Yritus_ID = new SelectList(db.Yritus1, "ID", "Ürituse_nimi", osavotjad.Yritus_ID);
            return View(osavotjad);
        }

        // POST: Osavotjads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Eesnimi,Perenimi,Isikukood,Makskmisviis,Lisainfo,Yritus_ID")] Osavotjad osavotjad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osavotjad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Yritus_ID = new SelectList(db.Yritus1, "ID", "Ürituse_nimi", osavotjad.Yritus_ID);
            return View(osavotjad);
        }

        // GET: Osavotjads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osavotjad osavotjad = await db.Osavotjads.FindAsync(id);
            if (osavotjad == null)
            {
                return HttpNotFound();
            }
            return View(osavotjad);
        }

        // POST: Osavotjads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Osavotjad osavotjad = await db.Osavotjads.FindAsync(id);
            db.Osavotjads.Remove(osavotjad);
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
