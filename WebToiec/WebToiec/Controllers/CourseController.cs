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
    public class CourseController : Controller
    {
        khoaHocDAL khDAL = new khoaHocDAL();
        baiGiangDAL bgDAl = new baiGiangDAL();
        chuDeTuVungDAL chuDeDAL = new chuDeTuVungDAL();
        tuVungDAL tvungDAL = new tuVungDAL();
        chiTietTuVungDAL chiTietTuDAL = new chiTietTuVungDAL();

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

        public void GetChuDeTuVung()
        {
            List<CHUDE_TUVUNG> cd = new List<CHUDE_TUVUNG>();
            cd = chuDeDAL.GetList();

            ViewData["ChuDes"] = cd;
        }

        public void GetDSTuVung(int id)
        {
            var list_TuVung = chiTietTuDAL.GetDVByMaChuDe(id);
            int a = 1;

            List<Model_TuVung> model_TV = new List<Model_TuVung>();
            foreach (var tv in list_TuVung)
            {
                var b = tvungDAL.GetDVByMa(tv.ID_TUVUNG);
                var model = new Model_TuVung()
                {
                    ID_TuVung = a,
                    Tu_Vung = b.TU,
                    MA_CHU_DE = tv.MA_CHU_DE,
                    NGHIA_CUA_TU = tv.NGHIA_CUA_TU,
                    TheLoai = b.THELOAI,
                    PHAT_AM = tv.PHAT_AM,
                    PHIEN_AM = tv.PHIEN_AM,
                    VI_DU = tv.VI_DU,
                    HIN_HANH = tv.HIN_HANH
                };
                model_TV.Add(model);
                a++;
            }
            Session["TuVung"] = model_TV;
        }
        #endregion

        public ActionResult GetListBaiGiang()
        {
            GetBaiGiangs();

            return View();
        }

        public ActionResult GetChiTietBaiGiang(int id)
        {
            if (Session["tenTK"] != null)
            {
                var item = bgDAl.GetDVByMa(id);

                return View(item);
            }
            else
            {
                return RedirectToAction("Login","Default");
            }
        }

        public ActionResult GetListChuDe()
        {
            GetChuDeTuVung();
            Session.Remove("TuVung");
            return View();
        }

        public ActionResult GetChiTietChuDe(int id)
        {
            var item_chuDe = chuDeDAL.GetDVByMa(id);
            GetDSTuVung(id);

            return View(item_chuDe);
        }

        public ActionResult HocTuVung(int id)
        {
            var listTV = Session["TuVung"] as List<Model_TuVung>;
            var item = listTV.FirstOrDefault(m => m.ID_TuVung == id);
            return View(item);
        }

        public PartialViewResult TuVung(int id)
        {
            var listTV = Session["TuVung"] as List<Model_TuVung>;
            var item = listTV.FirstOrDefault(m => m.ID_TuVung == id);

            return PartialView(item);
            
        }
    }
}