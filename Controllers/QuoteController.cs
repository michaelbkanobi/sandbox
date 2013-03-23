using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuoteMachine.Models;

namespace QuoteMachine.Controllers
{
    public class QuoteController : Controller
    {
        private QuoteMachineContext db = new QuoteMachineContext();

        //
        // GET: /Quote/

        public ActionResult Index()
        {
            return View(db.QuoteModels.ToList());
        }

        //
        // GET: /Quote/Details/5

        public ActionResult Details(int id = 0)
        {
            QuoteModel quotemodel = db.QuoteModels.Find(id);
            if (quotemodel == null)
            {
                return HttpNotFound();
            }
            return View(quotemodel);
        }

        //
        // GET: /Quote/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Quote/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuoteModel quotemodel)
        {
            if (ModelState.IsValid)
            {
                db.QuoteModels.Add(quotemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quotemodel);
        }

        //
        // GET: /Quote/Edit/5

        public ActionResult Edit(int id = 0)
        {
            QuoteModel quotemodel = db.QuoteModels.Find(id);
            if (quotemodel == null)
            {
                return HttpNotFound();
            }
            return View(quotemodel);
        }

        //
        // POST: /Quote/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuoteModel quotemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotemodel);
        }

        //
        // GET: /Quote/Delete/5

        public ActionResult Delete(int id = 0)
        {
            QuoteModel quotemodel = db.QuoteModels.Find(id);
            if (quotemodel == null)
            {
                return HttpNotFound();
            }
            return View(quotemodel);
        }

        //
        // POST: /Quote/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuoteModel quotemodel = db.QuoteModels.Find(id);
            db.QuoteModels.Remove(quotemodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}