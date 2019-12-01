using DAL.DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebToiec.Areas.Admin.Models;

namespace WebToiec.Areas.Admin.Controllers
{

    public class HomeController : Controller
    {
        adminDAL admin_DAL = new adminDAL();
        ADMIN admin;
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create_Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_Admin(Admin_Model admin_Model)
        {
            try
            {
                admin = new ADMIN();
                admin.ID = admin_Model.ID;
                admin.TAIKHOAN = admin_Model.Username;
                admin.MATKHAU = admin_Model.Password;
                admin_DAL.Add(admin);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Showdata_Admin()
        {
            var item = admin_DAL.GetList();
            return View(item);
        }

        public ActionResult Update_Admin(string ma)
        {
            var item = admin_DAL.GetDVByMa(ma);
            return View(item);
        }
        [HttpPost]
        public ActionResult Update_Admin(Admin_Model admin_Model)
        {
            admin = new ADMIN();
            admin.MATKHAU = admin_Model.Password;
            int kq = admin_DAL.Update(admin);
            if (kq == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Cập nhật thất bại";
                return View();
            }
            
        }
    }
}