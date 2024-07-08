using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_Recapitulatif.DAL;
using TP_Recapitulatif.Models;

namespace TP_Recapitulatif.Controllers
{
    public class OuvragesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Ouvrages
        public ActionResult Index()
        {
            var ouvrages = db.Ouvrages.Include(o => o.Categorie);
            return View(ouvrages.ToList());
        }

        // GET: Ouvrages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // GET: Ouvrages/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Ouvrages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,CategorieId")] Ouvrage ouvrage)
        {
            if (ModelState.IsValid)
            {
                db.Ouvrages.Add(ouvrage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name", ouvrage.CategorieId);
            return View(ouvrage);
        }

        // GET: Ouvrages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name", ouvrage.CategorieId);
            return View(ouvrage);
        }

        // POST: Ouvrages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,CategorieId")] Ouvrage ouvrage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ouvrage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name", ouvrage.CategorieId);
            return View(ouvrage);
        }

        // GET: Ouvrages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // POST: Ouvrages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            db.Ouvrages.Remove(ouvrage);
            db.SaveChanges();
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
