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

    [CustomAuthorize (Roles = "admin, user")]

    public class PhoneDetailsController : Controller
    {
        private AzureProjectEntities1 db = new AzureProjectEntities1();

        // GET: PhoneDetails
        public ActionResult Index()
        {
            var phoneDetail = db.PhoneDetail.Include(p => p.PhoneRefBrands);
            return View(phoneDetail.ToList());
        }

        // GET: PhoneDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneDetail phoneDetail = db.PhoneDetail.Find(id);
            if (phoneDetail == null)
            {
                return HttpNotFound();
            }
            return View(phoneDetail);
        }

        // GET: PhoneDetails/Create
        public ActionResult Create()
        {
            ViewBag.PhoneBrandID = new SelectList(db.PhoneRefBrands, "PhoneRefBrandID", "PhoneRefBrandName");
            return View();
        }

        // POST: PhoneDetails/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneID,PhoneDescription,PhoneBrandID,PhoneColor")] PhoneDetail phoneDetail)
        {
            if (ModelState.IsValid)
            {
                db.PhoneDetail.Add(phoneDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhoneBrandID = new SelectList(db.PhoneRefBrands, "PhoneRefBrandID", "PhoneRefBrandName", phoneDetail.PhoneBrandID);
            return View(phoneDetail);
        }

        // GET: PhoneDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneDetail phoneDetail = db.PhoneDetail.Find(id);
            if (phoneDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhoneBrandID = new SelectList(db.PhoneRefBrands, "PhoneRefBrandID", "PhoneRefBrandName", phoneDetail.PhoneBrandID);
            return View(phoneDetail);
        }

        // POST: PhoneDetails/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneID,PhoneDescription,PhoneBrandID,PhoneColor")] PhoneDetail phoneDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhoneBrandID = new SelectList(db.PhoneRefBrands, "PhoneRefBrandID", "PhoneRefBrandName", phoneDetail.PhoneBrandID);
            return View(phoneDetail);
        }

        // GET: PhoneDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneDetail phoneDetail = db.PhoneDetail.Find(id);
            if (phoneDetail == null)
            {
                return HttpNotFound();
            }
            return View(phoneDetail);
        }

        // POST: PhoneDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneDetail phoneDetail = db.PhoneDetail.Find(id);
            db.PhoneDetail.Remove(phoneDetail);
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
