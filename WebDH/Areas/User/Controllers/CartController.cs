﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDH.Models;

namespace WebDH.Areas.User.Controllers
{
    public class CartController : Controller
    {
        // GET: User/Cart
        private BANDONGHOEntities1 db = new BANDONGHOEntities1();
        // GET: Cart
        public ActionResult Index(List<CHITIETDONHANG> sanPhams)
        {
            return View(sanPhams);
        }
        [HttpPost]
        public ActionResult LoadSanPham(List<CHITIETDONHANG> sanPhams)
        {
            foreach (var item in sanPhams)
            {
                // Lấy thông tin sản phẩm từ bảng SANPHAM và liên kết với KHUYENMAI
                var sanPham = db.SANPHAMs
                    .Include("KHUYENMAI")
                    .Where(sp => sp.MASP == item.MASP)
                    .FirstOrDefault();

                // Kiểm tra xem SANPHAM của item đã được khởi tạo chưa
                if (item.SANPHAM == null)
                {
                    item.SANPHAM = new SANPHAM(); // Hoặc thực hiện khởi tạo theo cách khác tùy vào cấu trúc của bạn
                }

                // Lấy giá từ cơ sở dữ liệu tùy thuộc vào loại sản phẩm và khuyến mãi
                if (sanPham != null)
                {
                    if (sanPham.MALOAISP == "LP00003" && sanPham.KHUYENMAI != null && sanPham.KHUYENMAI.PHAMTRAM.HasValue)
                    {
                        // Sản phẩm giảm giá
                        item.SANPHAM.DONGIA = sanPham.DONGIA * (1 - sanPham.KHUYENMAI.PHAMTRAM.Value / 100);
                    }
                    else
                    {
                        // Sản phẩm không giảm giá hoặc không có giá bán
                        item.SANPHAM.DONGIA = sanPham.DONGIA ?? 0;
                    }
                }
            }

            return PartialView("_LoadSanPhamRow", sanPhams);
        }


        public ActionResult ThongTinSanPham(int idSanPham, int SoLuong)
        {
            ViewBag.SoLuong = SoLuong;
            return PartialView("_SanPhamRow", new mapSanPham().ChiTiet(idSanPham));
        }
    }
}