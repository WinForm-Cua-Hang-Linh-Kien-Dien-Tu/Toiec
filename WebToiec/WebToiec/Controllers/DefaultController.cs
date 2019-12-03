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
        tinTucDAL ttDAL = new tinTucDAL();
        baiGiangDAL bgDAl = new baiGiangDAL();

        // GET: Default
        public ActionResult Index()
        {
            GetBaiGiangs();
            GetKhoaHocs();
            return View();
        }

        #region Get Đủ Thứ
        public void GetKhoaHocs()
        {
            List<KHOAHOC> kh = new List<KHOAHOC>();
            kh = khDAL.GetListLimit();

            ViewData["khoaHocs"] = kh;
        }

        public void GetBaiGiangs()
        {
            List<BAIGIANG> bg = new List<BAIGIANG>();
            bg = bgDAl.GetListLimit();

            ViewData["BaiGiangs"] = bg;
        }
        #endregion

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
            if (item != null)
            {
                Session["tenTK"] = item.TAI_KHOAN_USER;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Bạn Nhập Sai Tài Khoản Hoặc Mật Khẩu. Vui Lòng Nhập Lại";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Model_User model)
        {
            USERS user = new USERS();
            user.TAI_KHOAN_USER = model.TAI_KHOAN_USER;
            user.MAT_KHAU_USER = model.MAT_KHAU_USER;
            user.NGAY_TAO = DateTime.Now;

            int kt = uDAL.GetItem(user.TAI_KHOAN_USER);
            if (kt == 0)
            {
                int kq = uDAL.Add(user);
                if (kq == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Message"] = "Tạo Tài Khoản Thất Bại";
                    return View("Register");
                }
            }
            else
            {
                TempData["Message"] = "UserName Đã Tồn Tại";
                return View("Register");
            }
           
        }

        public ActionResult TinTuc()
        {
            List<TIN_TUC> tt = new List<TIN_TUC>();
            tt = ttDAL.GetList();

            ViewData["khoaHocs"] = tt;
            return View();
        }

        [HttpPost]
        public ActionResult TinTuc(Model_TinTuc model)
        {
            List<TIN_TUC> tt = new List<TIN_TUC>();
            if (model.TEN_TIN_TUC != null)
            {
                tt = ttDAL.GetList(model.TEN_TIN_TUC);
                ViewData["khoaHocs"] = tt;
            }
            else
            {
                tt = ttDAL.GetList(model.NGAY_DANG);
                ViewData["khoaHocs"] = tt;
            }

            return View();
        }

        public ActionResult ChiTieTTinTuc(int id)
        {
            var item = ttDAL.GetDVByMa(id);
            
            return View(item);
        }

    }
}