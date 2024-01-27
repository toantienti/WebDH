using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDH.Models;

namespace WebDH.Areas.User.Controllers
{
    public class UserController : Controller
    {
        // GET: User/User

        private BANDONGHOEntities1 db = new BANDONGHOEntities1();
        // GET: User
        public ActionResult Index(string loai)
        {
            List<SANPHAM> danhSachSanPham = db.SANPHAMs.Take(8).ToList();
            if (!string.IsNullOrEmpty(loai))
            {
                danhSachSanPham = danhSachSanPham
                    .Where(s => s.LOAISANPHAM.TENLOAISP == loai)
                    .ToList();
            }
            return View(danhSachSanPham);
        }
    }
}