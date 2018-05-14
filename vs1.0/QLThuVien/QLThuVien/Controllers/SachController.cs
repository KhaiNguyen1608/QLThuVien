using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace QLThuVien.Controllers
{
    public class SachController : Controller
    {
        private ThuVienContent db = new ThuVienContent();

        // GET: Sach
        public ActionResult Index(int ? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var SACH = db.SACHes.Include(s => s.LoaiSach);
            return View(db.SACHes.ToList().OrderBy(n => n.Masach).ToPagedList(pageNumber, pageSize));
        }

        // GET: Sach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: Sach/Create
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenCD");
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masach,Tensach,MaLoaiSach,Mota,Hinhminhhoa,MaCD,MaNXB,Ngaycapnhat")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenCD", sACH.MaCD);
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sACH.MaLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // GET: Sach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenCD", sACH.MaCD);
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sACH.MaLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masach,Tensach,MaLoaiSach,Mota,Hinhminhhoa,MaCD,MaNXB,Ngaycapnhat")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenCD", sACH.MaCD);
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sACH.MaLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // GET: Sach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
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
