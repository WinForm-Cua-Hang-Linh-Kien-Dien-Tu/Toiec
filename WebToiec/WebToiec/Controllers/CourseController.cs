using DAL.DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebToiec.Controllers
{
    public class CourseController : Controller
    {
        khoaHocDAL khDAL = new khoaHocDAL();
        // GET: Coures
        public ActionResult IndexCourse()
        {
            List<KHOAHOC> kh = new List<KHOAHOC>();
            kh = khDAL.GetList();

            ViewData["khoaHocs"] = kh;
           
            return View();
        }
    }
}