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
        baiGiangDAL bgDAl = new baiGiangDAL();
        
        // GET: Coures
        public ActionResult IndexCourse()
        {
            GetKhoaHocs();
            GetBaiGiangs();
           
            return View();
        }

        public ActionResult ChiTietCourse(int id)
        {
            var item = khDAL.GetDVByMa(id);

            return View(item);
        }

        #region Get Đủ Thứ
        public void GetKhoaHocs()
        {
            List<KHOAHOC> kh = new List<KHOAHOC>();
            kh = khDAL.GetList();

            ViewData["khoaHocs"] = kh;
        }

        public void GetBaiGiangs()
        {
            List<BAIGIANG> bg = new List<BAIGIANG>();
            bg = bgDAl.GetList();

            ViewData["BaiGiangs"] = bg;
        }
        #endregion

        public ActionResult GetBaiGiang()
        {
            GetBaiGiangs();

            return View();
        }


    }
}