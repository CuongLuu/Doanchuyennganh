using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using DocumentFormat.OpenXml.Bibliography;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        DBcontext context = new DBcontext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult ProfileUser()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditProfileUser(int id)
        {

            NguoiDung user = context.NguoiDungs.SingleOrDefault(p => p.maND == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("EditProfileUser")]
        public ActionResult EditProfileUser(NguoiDung user)
        {

            NguoiDung dbUpdate = context.NguoiDungs.FirstOrDefault(p => p.maND == user.maND);
            if (dbUpdate != null)
            {
                //get date modified
                user.ngaysua = DateTime.Now;
                // get photo
                if (user.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(user.ImageUpload.FileName);
                    string extension = Path.GetExtension(user.ImageUpload.FileName);
                    filename = filename + extension;
                    user.anh = filename;
                    string path = Path.Combine(Server.MapPath("~/Image/ImageUpload/"), filename);
                    user.ImageUpload.SaveAs(path);
                }
                context.NguoiDungs.AddOrUpdate(user);
                context.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("ProfileUser", "Home", new { id = user.maND });
        }
        /* [HttpPost, ActionName("EditProfileUser")]
         public ActionResult EditProfileUser(NguoiDung user, HttpPostedFileBase uploadhinh)
         {
             NguoiDung dbUpdate = context.NguoiDungs.FirstOrDefault(p => p.maND == user.maND);
             if (dbUpdate != null)
             {
                 //get date modified
                 user.ngaysua = DateTime.Now;
                 // get photo
                 if (uploadhinh != null && uploadhinh.ContentLength > 0)
                 {
                     int id = user.maND;
                     string filename = "";
                     int index = uploadhinh.FileName.IndexOf('.');
                     filename = "user" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                     string path = Path.Combine(Server.MapPath("~/Image/ImageUpload"), filename);
                     uploadhinh.SaveAs(path);
                     dbUpdate.anh = filename;
                 }
                 context.NguoiDungs.AddOrUpdate(user);
                 context.SaveChanges();
             }
             return RedirectToAction("Index", "Home");
         }
 */
        public ActionResult ProfileAdmin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}