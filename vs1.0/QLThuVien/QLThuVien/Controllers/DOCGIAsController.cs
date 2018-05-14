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
    public class DOCGIAsController : Controller
    {
        private ThuVienContent db = new ThuVienContent();

        // GET: DOCGIAs
        public ActionResult Index()
        {
            return View(db.DOCGIAs.ToList());
        }

        // GET: DOCGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(dOCGIA);
        }

        // GET: DOCGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOCGIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,TenDG,DiaChi,DienThoai,Email")] DOCGIA dOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.DOCGIAs.Add(dOCGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOCGIA);
        }

        // GET: DOCGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(dOCGIA);
        }

        // POST: DOCGIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,TenDG,DiaChi,DienThoai,Email")] DOCGIA dOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCGIA);
        }

        // GET: DOCGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(dOCGIA);
        }

        // POST: DOCGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            db.DOCGIAs.Remove(dOCGIA);
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
