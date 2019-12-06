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
        khoaHocDAL _khoaHocDAL = new khoaHocDAL();
        usersDAL _usersDAL = new usersDAL();
        tinTucDAL _tinTucDAL = new tinTucDAL();
        baiGiangDAL _baiGiangDAL = new baiGiangDAL();
        userProfileDAL _userProfileDAL = new userProfileDAL();
        adminDAL _adminDAL = new adminDAL();

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
            kh = _khoaHocDAL.GetListLimit();

            ViewData["khoaHocs"] = kh;
        }

        public void GetBaiGiangs()
        {
            List<BAIGIANG> bg = new List<BAIGIANG>();
            bg = _baiGiangDAL.GetListLimit();

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
            var item = _usersDAL.GetItem(model.TAI_KHOAN_USER, model.MAT_KHAU_USER);
            var admin = _adminDAL.GetDVByMa(model.TAI_KHOAN_USER, model.MAT_KHAU_USER);
            if (item != null)
            {
                Session["tenTK"] = item.TAI_KHOAN_USER;
                Session["UserId"] = item.USERID;
                return RedirectToAction("Index");
            }
            else
            {
                if (admin != null)
                {
                    Session["tenTK"] = admin.TAIKHOAN;
                    Session["UserId"] = admin.ID;
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    TempData["Message"] = "Bạn Nhập Sai Tài Khoản Hoặc Mật Khẩu. Vui Lòng Nhập Lại";
                    return View();
                }
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

            int kt = _usersDAL.GetItem(user.TAI_KHOAN_USER);
            if (kt == 0)
            {
                int kq = _usersDAL.Add(user);
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

        public ActionResult UserProfile()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            var user = _userProfileDAL.GetDVByMa(id);
            return View(user);
        }

        public ActionResult LogOut()
        {
            Session.Remove("UserId");
            Session.Remove("tenTK");
            Index();
            return View("Index");
        }

        #region Tin Tức
        public ActionResult TinTuc()
        {
            List<TIN_TUC> tt = new List<TIN_TUC>();
            tt = _tinTucDAL.GetList();

            ViewData["khoaHocs"] = tt;
            return View();
        }

        [HttpPost]
        public ActionResult TinTuc(Model_TinTuc model)
        {
            List<TIN_TUC> tt = new List<TIN_TUC>();
            if (model.TEN_TIN_TUC != null)
            {
                tt = _tinTucDAL.GetList(model.TEN_TIN_TUC);
                ViewData["khoaHocs"] = tt;
            }
            else
            {
                tt = _tinTucDAL.GetList(model.NGAY_DANG);
                ViewData["khoaHocs"] = tt;
            }

            return View();
        }

        public ActionResult ChiTieTTinTuc(int id)
        {
            var item = _tinTucDAL.GetDVByMa(id);
            
            return View(item);
        }
        #endregion

    }
}