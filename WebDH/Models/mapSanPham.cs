using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDH.Models
{
    public class mapSanPham
    {
        public SANPHAM ChiTiet(int id)
        {
            BANDONGHOEntities1 db = new BANDONGHOEntities1();
            return db.SANPHAMs.Find(id);
        }
    }
}