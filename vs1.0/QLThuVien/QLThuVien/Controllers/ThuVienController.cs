using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class ThuVienController : Controller
    {
        ThuVienContent db = new ThuVienContent();
        // GET: ThuVien
        public ActionResult Index()
        {
            return View();
        }
    }
}