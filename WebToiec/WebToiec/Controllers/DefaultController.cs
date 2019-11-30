using DAL.DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebToiec.Models;

namespace WebToiec.Controllers
{
    public class DefaultController : Controller
    {
        khoaHocDAL khDAL = new khoaHocDAL();
        usersDAL uDAL = new usersDAL();

        // GET: Default
        public ActionResult Index()
        {
            List<KHOAHOC> kh = new List<KHOAHOC>();
            kh = khDAL.GetList();

            ViewData["khoaHocs"] = kh;
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Model_User model)
        {
            var item = uDAL.GetItem(model.TAI_KHOAN_USER, model.MAT_KHAU_USER);
            if(item != null)
            {
                Session["User"] = item.TAI_KHOAN_USER;
                RedirectToAction("Index");
            }
            return View();
        }
    }
}