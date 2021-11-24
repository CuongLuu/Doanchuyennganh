using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models.Context;
using Demo.Models;

namespace Demo.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        DBcontext context = new DBcontext();
        public ActionResult Payment()
        {
            if(Session["Account"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {

                //lấy thông tin giỏ hàng từ session
                
                Cart cart = Session["Cart"] as Cart;
                
                //gán dữu liệu cho table hóa đơn
                HoaDon objHoaDon = new HoaDon();
            objHoaDon.ghichu = "Đơn Hàng " + DateTime.Now.ToString("yyyyMMddHHmmss");
            objHoaDon.ngaymua = DateTime.Now;
            objHoaDon.sotien = cart.Items.Sum(p => p.Shopping_sanpham.gia * p.Shopping_soLuong);
            objHoaDon.soluong = cart.Items.Sum(p => p.Shopping_soLuong);
            context.HoaDons.Add(objHoaDon);
            context.SaveChanges();
                // gán dữ liệu vào table CTHD
                var listitem =  (List<CartItem>)Session["Cart"] ;
                int mahoadon = objHoaDon.maHD;
                List<CTHD> chitiethoadon = new List<CTHD>();
                foreach(var item in listitem)
                {
                    CTHD objCTHD = new CTHD();
                    objCTHD.maHD = item.Shopping_hoadon.maHD;
                    objCTHD.maCH = item.Shopping_sanpham.maCH;
                    objCTHD.maND = item.Shopping_nguoidung.maND;
                    objCTHD.maSP = item.Shopping_sanpham.maSP;
                    objCTHD.soluong = item.Shopping_hoadon.soluong;
                    objCTHD.giaban = item.Shopping_sanpham.gia;
                    objCTHD.thanhtien = item.Shopping_hoadon.sotien;
                   
                    chitiethoadon.Add(objCTHD);
                    
                }
                context.CTHDs.AddRange(chitiethoadon);
                context.SaveChanges();
            return View();

            }
        }
        public ActionResult Thongbao()
        {
            return View();
        }
    }
}