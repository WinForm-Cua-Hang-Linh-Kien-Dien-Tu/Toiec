using DAL.DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebToiec.Controllers
{
    public class DefaultController : Controller
    {
        khoaHocDAL khDAL = new khoaHocDAL();

        // GET: Default
        public ActionResult Index()
        {
            List<KHOAHOC> kh = new List<KHOAHOC>();
            kh = khDAL.GetList();

            ViewData["khoaHocs"] = kh;
            return View();
        }
    }
}