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
        user_KhoaHocDAL user_KhoaDAL = new user_KhoaHocDAL();
        user_BaiGiangDAL user_BgDAL = new user_BaiGiangDAL(); 

        // GET: Coures
        public ActionResult IndexCourse()
        {
            GetKhoaHocs();
            GetBaiGiangs();
           
            return View();
        }

        #region Khóa Học
        public ActionResult ChiTietCourse(int id)
        {
            var item = khDAL.GetDVByMa(id);
            TempData["DSBaiGiangKH"] = bgDAl.GetList(id);

            return View(item);
        }

        /// <summary>
        /// Đăng Ký Khóa Học
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChiTietCourse(int id, string userId)
        {
            try
            {
                userId = Session["UserId"].ToString();
                var DSuserbaiGiang = bgDAl.GetList(id);
                if (userId != null)
                {
                    USER_KHOAHOC model = new USER_KHOAHOC();
                    model.ID_KH = id;
                    model.USERID = Convert.ToInt32(userId);
                    model.TrangThai = "Chưa Hoàn Thành";

                    foreach(var item in DSuserbaiGiang)
                    {
                        USER_BAIGIANG u = new USER_BAIGIANG
                        {
                            USERID = Convert.ToInt32(userId),
                            ID_BAIGIANG = item.ID_BAIGIANG,
                            TRANG_THAI = "Chưa Hoàn Thành"
                        };

                        int kq2 = user_BgDAL.Add(u);
                    }
                    int kq = user_KhoaDAL.Add(model);
                    return RedirectToAction("IndexCourse", "Course");

                }
                else
                {
                    return RedirectToAction("Login", "Default");
                }
            }
            catch
            {
                return RedirectToAction("IndexCourse", "Course");
            }
        }


        #endregion

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

        #region Bài Giảng
        public ActionResult GetListBaiGiang()
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"].ToString());
                var DSuserbaiGiang = user_BgDAL.GetList(userId);
                List<Model_BaiGiang> baiGiangs = new List<Model_BaiGiang>();

                foreach (var item in DSuserbaiGiang)
                {
                    var bg = bgDAl.GetDVByMa(item.ID_BAIGIANG);
                    Model_BaiGiang model = new Model_BaiGiang
                    {
                        ID_BAIGIANG = bg.ID_BAIGIANG,
                        ID_KH = bg.ID_KH,
                        NOI_DUNG_BAI_GIANG = bg.NOI_DUNG_BAI_GIANG,
                        VIDEO = bg.VIDEO,
                        PART = bg.PART,
                        GIANG_VIEN = bg.GIANG_VIEN,
                        TEN_BAI_GIANG = bg.TEN_BAI_GIANG,
                        DANH_GIA = bg.DANH_GIA
                    };

                    baiGiangs.Add(model);
                }
                TempData["model_BG"] = baiGiangs;

                return View();
            }
            else
            {
                return View();
            }
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
        #endregion

        #region Học Từ Vựng
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

        public ActionResult TuVung(int id)
        {
            var listTV = Session["TuVung"] as List<Model_TuVung>;
            var item = listTV.FirstOrDefault(m => m.ID_TuVung == id);

            return Json(item, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bài Tập
        
        #endregion

    }
}