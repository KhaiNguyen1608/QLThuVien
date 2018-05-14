using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class CHUDEController : Controller
    {
        private ThuVienContent db = new ThuVienContent();

        // GET: CHUDE
        public ActionResult Index()
        {
            return View(db.CHUDEs.ToList());
        }

        // GET: CHUDE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDEs.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // GET: CHUDE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHUDE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCD,TenCD")] CHUDE cHUDE)
        {
            if (ModelState.IsValid)
            {
                db.CHUDEs.Add(cHUDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUDE);
        }

        // GET: CHUDE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDEs.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // POST: CHUDE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCD,TenCD")] CHUDE cHUDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUDE);
        }

        // GET: CHUDE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDEs.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // POST: CHUDE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUDE cHUDE = db.CHUDEs.Find(id);
            db.CHUDEs.Remove(cHUDE);
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
