using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class DatHangController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: DatHang
        public ActionResult Index()
        {
            var cTHDs = db.CTHDs.Include(c => c.Cuahang).Include(c => c.HoaDon).Include(c => c.NguoiDung).Include(c => c.SanPham);
            return View(cTHDs.ToList());
        }

        // GET: DatHang/Details/5
       
    }
}
