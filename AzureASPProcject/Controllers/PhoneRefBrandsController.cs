using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzureASPProcject;

namespace AzureASPProcject.Controllers
{

    [CustomAuthorize (Roles = "admin")]

    public class PhoneRefBrandsController : Controller
    {
        private AzureProjectEntities1 db = new AzureProjectEntities1();

        // GET: PhoneRefBrands
        public ActionResult Index()
        {
            return View(db.PhoneRefBrands.ToList());
        }

        // GET: PhoneRefBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneRefBrands phoneRefBrands = db.PhoneRefBrands.Find(id);
            if (phoneRefBrands == null)
            {
                return HttpNotFound();
            }
            return View(phoneRefBrands);
        }

        // GET: PhoneRefBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneRefBrands/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneRefBrandID,PhoneRefBrandName")] PhoneRefBrands phoneRefBrands)
        {
            if (ModelState.IsValid)
            {
                db.PhoneRefBrands.Add(phoneRefBrands);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phoneRefBrands);
        }

        // GET: PhoneRefBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneRefBrands phoneRefBrands = db.PhoneRefBrands.Find(id);
            if (phoneRefBrands == null)
            {
                return HttpNotFound();
            }
            return View(phoneRefBrands);
        }

        // POST: PhoneRefBrands/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneRefBrandID,PhoneRefBrandName")] PhoneRefBrands phoneRefBrands)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneRefBrands).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phoneRefBrands);
        }

        // GET: PhoneRefBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneRefBrands phoneRefBrands = db.PhoneRefBrands.Find(id);
            if (phoneRefBrands == null)
            {
                return HttpNotFound();
            }
            return View(phoneRefBrands);
        }

        // POST: PhoneRefBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneRefBrands phoneRefBrands = db.PhoneRefBrands.Find(id);
            db.PhoneRefBrands.Remove(phoneRefBrands);
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
