using DAL.DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebToiec.Areas.Admin.Models;
using WebToiec.Models;

namespace WebToiec.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        tuVungDAL _TuVungDAL = new tuVungDAL();
        chuDeTuVungDAL _chuDeTuVungDAL = new chuDeTuVungDAL();
        chiTietTuVungDAL _chiTietTuVungDAL = new chiTietTuVungDAL();
        khoaHocDAL _khoaHocDAL = new khoaHocDAL();
        baiGiangDAL _baiGiangDAL = new baiGiangDAL();
        tinTucDAL _tinTucDAL = new tinTucDAL();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }


        #region Chủ Đề Từ Vựng

        public ActionResult ChuDeTV()
        {
            var list_CD = _chuDeTuVungDAL.GetList();

            return View(list_CD);
        }

        public ActionResult Add_ChuDe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_ChuDe(Model_ChuDe model)
        {
            if (ModelState.IsValid)
            {
                CHUDE_TUVUNG item = new CHUDE_TUVUNG
                {
                    TEN_CHU_DE = model.TEN_CHU_DE,
                    TONG_SO_TU = 0
                };

                _chuDeTuVungDAL.Add(item);
                TempData["SuccesMessage"] = "Create SuccessFully";
                return RedirectToAction("ChuDeTV");
            }
            return View(model);
        }

        public ActionResult Edit_ChuDe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _chuDeTuVungDAL.GetDVByMa(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit_ChuDe(CHUDE_TUVUNG model)
        {
            int kq = _chuDeTuVungDAL.Update(model);
            TempData["SuccesMessage"] = "Save SuccessFully";

            return RedirectToAction("ChuDeTV");
        }

        public ActionResult Delete_ChuDe(int id)
        {
            int kq = _chuDeTuVungDAL.Delete(id);
            TempData["SuccesMessage"] = "Delete SuccessFully";
            return RedirectToAction("ChuDeTV");
        }

        #endregion

        #region Từ Vựng

        public ActionResult TuVung()
        {
            var list_TV = _TuVungDAL.GetList();

            return View(list_TV);
        }

        public ActionResult Add_TuVung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_TuVung(Model_TuVung model)
        {
            if (ModelState.IsValid)
            {
                TUVUNG item = new TUVUNG {
                    TU = model.Tu_Vung,
                    THELOAI = model.TheLoai
                };
                int kq = _TuVungDAL.Add(item);
                TempData["SuccesMessage"] = "Create SuccessFully";
                return RedirectToAction("TuVung");
            }
            return View(model);
        }

        public ActionResult Edit_TuVung(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _TuVungDAL.GetDVByMa(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit_TuVung(TUVUNG model)
        {
            int kq = _TuVungDAL.Update(model);
            TempData["SuccesMessage"] = "Save SuccessFully";
            return RedirectToAction("TuVung");
        }

        public ActionResult Delete_TuVung(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int kq = _TuVungDAL.Delete(id);
            TempData["SuccesMessage"] = "Delete SuccessFully";
            return RedirectToAction("TuVung");
        }

        #endregion

        #region Chi Tiết Từ Vựng

        public ActionResult ToanBoChiTietTuVung()
        {
            var list_TV = _chiTietTuVungDAL.GetList();
            var list = GetDSChiTietTuVung(list_TV).OrderBy(m=>m.Tu_Vung);
            return View(list);
        }

        public ActionResult ChiTietTuVung(int? id)
        {
            var list_TV = _chiTietTuVungDAL.GetList(id);
            var list = GetDSChiTietTuVung(list_TV);
            return View(list);
        }

        public ActionResult Add_ChiTietTuVung()
        {
            Selected_ChuDe();
            Selected_TuVung();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add_ChiTietTuVung(IEnumerable<HttpPostedFileBase> UpHinh, Model_TuVung model)
        {
            try
            {
                HttpPostedFileBase file1;
                HttpPostedFileBase file2;

                if (ModelState.IsValid)
                {
                    file1 = UpHinh.ElementAt(0);
                    file2 = UpHinh.ElementAt(1);
                    if (UpHinh.ElementAt(0) != null && UpHinh.ElementAt(1) != null)
                    {
                        if (file1 != null && file1.ContentLength > 0 && file2 != null && file2.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file1.FileName);
                            string path = Path.Combine(Server.MapPath("~/Resource/Voice/"), fileName); //Get the first file path and save to folder
                            file1.SaveAs(path);

                            var fileName2 = Path.GetFileName(file2.FileName);
                            string path2 = Path.Combine(Server.MapPath("~/Resource/Image/"), fileName2);  //Get the second file path and save to folder
                            file2.SaveAs(path2);

                            int maTV = Convert.ToInt32(Request.Form["DSTuVung"]);
                            int maCD = Convert.ToInt32(Request.Form["DSChuDe"]);

                            var kqTimkiem = _chiTietTuVungDAL.GetDVByMa(maCD, maTV);
                            if (kqTimkiem == null)
                            {
                                CHI_TIET_TU_VUNG item = new CHI_TIET_TU_VUNG
                                {
                                    ID_TUVUNG = maTV,
                                    MA_CHU_DE = maCD,
                                    NGHIA_CUA_TU = model.NGHIA_CUA_TU,
                                    PHIEN_AM = model.PHIEN_AM,
                                    VI_DU = model.VI_DU,
                                    PHAT_AM = fileName,
                                    HIN_HANH = fileName2,
                                };
                                int kq = _chiTietTuVungDAL.Add(item);
                                TempData["SuccesMessage"] = "Create SuccessFully";
                                return RedirectToAction("ChiTietTuVung", new { id = item.ID_TUVUNG });
                            }
                            else
                            {
                                Selected_ChuDe();
                                Selected_TuVung();
                                TempData["SuccesMessage"] = "The vocabulary exist in Topic";
                                return View(model);
                            }
                        }
                        else
                        {
                            Selected_ChuDe();
                            Selected_TuVung();
                            TempData["SuccesMessage"] = "You are not chose file";
                            return View(model);
                        }
                    }

                }
                return View(model);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Edit_ChiTietTuVung(int? id)
        {
            Selected_TuVung();
            Selected_ChuDe();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _chiTietTuVungDAL.GetDVByMa(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_ChiTietTuVung(IEnumerable<HttpPostedFileBase> UpHinh, CHI_TIET_TU_VUNG model)
        {
            try
            {
                HttpPostedFileBase file1;
                HttpPostedFileBase file2;

                if (ModelState.IsValid)
                {
                    file1 = UpHinh.ElementAt(0);
                    file2 = UpHinh.ElementAt(1);
                    if (UpHinh.ElementAt(0) != null && UpHinh.ElementAt(1) != null)
                    {
                        if (file1 != null && file1.ContentLength > 0 && file2 != null && file2.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file1.FileName);
                            string path = Path.Combine(Server.MapPath("~/Resource/Voice/"), fileName); //Get the first file path and save to folder
                            file1.SaveAs(path);

                            var fileName2 = Path.GetFileName(file2.FileName);
                            string path2 = Path.Combine(Server.MapPath("~/Resource/Image/"), fileName2);  //Get the second file path and save to folder
                            file2.SaveAs(path2);

                            int maTV = Convert.ToInt32(Request.Form["DSTuVung"]);
                            int maCD = Convert.ToInt32(Request.Form["DSChuDe"]);

                            model.ID_TUVUNG = maTV;
                            model.MA_CHU_DE = maCD;
                            model.PHAT_AM = fileName;
                            model.HIN_HANH = fileName2;

                            int kq = _chiTietTuVungDAL.Update(model);
                            TempData["SuccesMessage"] = "Save SuccessFully";
                            Selected_ChuDe();
                            Selected_TuVung();
                            return RedirectToAction("ChiTietTuVung", new { id = model.ID_TUVUNG });               
                        }
                        else
                        {
                            Selected_ChuDe();
                            Selected_TuVung();
                            TempData["SuccesMessage"] = "You are not chose file";
                            return View(model);
                        }
                    }

                }
                return View(model);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Delete_ChiTietTuVung(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int kq = _chiTietTuVungDAL.Delete(id);
            TempData["SuccesMessage"] = "Delete SuccessFully";
            return RedirectToAction("ToanBoChiTietTuVung");
        }

        public List<Model_TuVung> GetDSChiTietTuVung(List<CHI_TIET_TU_VUNG> list_TV)
        {
            List<Model_TuVung> list_model = new List<Model_TuVung>();
            foreach (var item in list_TV)
            {
                Model_TuVung model = new Model_TuVung
                {
                    ID = item.ID,
                    ID_TuVung = item.ID_TUVUNG,
                    Tu_Vung = _TuVungDAL.GetTenTV(item.ID_TUVUNG),
                    NGHIA_CUA_TU = item.NGHIA_CUA_TU,
                    HIN_HANH = item.HIN_HANH,
                    PHAT_AM = item.PHAT_AM,
                    PHIEN_AM = item.PHIEN_AM,
                    VI_DU = item.VI_DU,
                    TEN_CHU_DE = _chuDeTuVungDAL.GetTenCD(item.MA_CHU_DE)
                };
                list_model.Add(model);
            }
            return list_model;
        }

        #region Hàm Gắn Selected
        /// <summary>
        /// selected danh sách chủ đề rồi add vào dropdownlist
        /// </summary>
        public void Selected_ChuDe()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var ds = _chuDeTuVungDAL.GetList();
            foreach (var item in ds)
            {
                items.Add(new SelectListItem { Text = item.TEN_CHU_DE, Value = item.MA_CHU_DE.ToString() });
            }
            ViewData["DSChuDe"] = items;
        }

        /// <summary>
        /// selected danh sách Từ Vưng rồi add vào dropdownlist
        /// </summary>
        public void Selected_TuVung()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var ds = _TuVungDAL.GetList();
            foreach (var item in ds)
            {
                items.Add(new SelectListItem { Text = item.TU, Value = item.ID_TUVUNG.ToString() });
            }
            ViewData["DSTuVung"] = items;
        }

        public void Selected_KhoaHoc()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var ds = _khoaHocDAL.GetList();
            foreach (var item in ds)
            {
                items.Add(new SelectListItem { Text = item.TEN_KH, Value = item.ID_KH.ToString() });
            }
            ViewData["DSKhoaHoc"] = items;
        }
        #endregion


        #endregion

        /// <summary>
        /// Hàm Lấy Up File
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string UpFile(HttpPostedFileBase a, string url)
        {
            string fileName = "";
            if (a != null && a.ContentLength > 0)
            {
                fileName = Path.GetFileName(a.FileName).ToString();
                string path = Path.Combine(Server.MapPath(url), fileName);
                a.SaveAs(path);
                return fileName;
            }
            else
                return fileName;

        }

        #region Khóa Học

        public ActionResult KhoaHoc()
        {
            var list_TV = _khoaHocDAL.GetList();

            return View(list_TV);
        }

        public ActionResult Add_KhoaHoc()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add_KhoaHoc(HttpPostedFileBase UpVideo, Model_KhoaHoc model)
        {
            if (ModelState.IsValid)
            {
                string video = UpFile(UpVideo, "~/Resource/Video/");
                KHOAHOC item = new KHOAHOC
                {
                    TEN_KH = model.TEN_KH,
                    THOI_GIAN = model.THOI_GIAN,
                    GIA_TIEN= model.GIA_TIEN,
                    GIOI_THIEU = model.GIOI_THIEU,
                    VIDEO_GIOI_THIEU= model.VIDEO_GIOI_THIEU,
                    LOAI_KH = model.lOAI_KH,
                    DANH_GIA = 1
                };
                int kq = _khoaHocDAL.Add(item);
                TempData["SuccesMessage"] = "Create SuccessFully";
                return RedirectToAction("KhoaHoc");
            }
            return View(model);
        }

        public ActionResult Edit_KhoaHoc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _khoaHocDAL.GetDVByMa(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_KhoaHoc(HttpPostedFileBase upVideo, KHOAHOC model)
        { 
            string video = UpFile(upVideo, "~/Resource/Video/");
            model.VIDEO_GIOI_THIEU = video;
            int kq = _khoaHocDAL.Update(model);
            TempData["SuccesMessage"] = "Save SuccessFully";
            return RedirectToAction("KhoaHoc");
        }

        public ActionResult Delete_KhoaHoc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int kq = _khoaHocDAL.Delete(id);
            TempData["SuccesMessage"] = "Delete SuccessFully";
            return RedirectToAction("BaiGiang");
        }

        public ActionResult Detail_KhoaHoc(int id)
        {
            var kq = _baiGiangDAL.GetList(id);
            
            return RedirectToAction("TuVung");
        }

        #endregion

        #region Bài Giảng

        public ActionResult BaiGiang(int? id)
        {
            if (id == null)
            {
                var list_TV = _baiGiangDAL.GetList();
                return View(list_TV);
            }
            else
            {
                var list_TV = _baiGiangDAL.GetList(id);
                return View(list_TV);
            }
        }

        public ActionResult Add_BaiGiang()
        {
            Selected_KhoaHoc();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add_BaiGiang(HttpPostedFileBase UpVideo, Model_BaiGiang model)
        {
            if (ModelState.IsValid)
            {
                string video = UpFile(UpVideo, "~/Resource/Video/");
                int maKH = Convert.ToInt32(Request.Form["DSKhoaHoc"]);
                BAIGIANG item = new BAIGIANG
                {
                    ID_KH = maKH,
                    NOI_DUNG_BAI_GIANG = model.NOI_DUNG_BAI_GIANG,
                    VIDEO = video,
                    PART = model.PART,
                    GIANG_VIEN = model.GIANG_VIEN,
                    TEN_BAI_GIANG = model.TEN_BAI_GIANG,
                    DANH_GIA = 1
                };
                int kq = _baiGiangDAL.Add(item);
                TempData["SuccesMessage"] = "Create SuccessFully";
                return RedirectToAction("BaiGiang");
            }
            return View(model);
        }

        public ActionResult Edit_BaiGiang(int? id)
        {
            Selected_KhoaHoc();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _baiGiangDAL.GetDVByMa(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit_BaiGiang(HttpPostedFileBase UpVideo, BAIGIANG model)
        {
            model.ID_KH= Convert.ToInt32(Request.Form["DSKhoaHoc"]);
            int kq = _baiGiangDAL.Update(model);
            TempData["SuccesMessage"] = "Save SuccessFully";
            return RedirectToAction("BaiGiang");
        }

        public ActionResult Delete_BaiGiang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int kq = _baiGiangDAL.Delete(id);
            TempData["SuccesMessage"] = "Delete SuccessFully";
            return RedirectToAction("BaiGiang");
        }

        public ActionResult Detail_BaiGiang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kq = _baiGiangDAL.GetDVByMa(id);
            Model_BaiGiang item = new Model_BaiGiang {
                ID_BAIGIANG = kq.ID_BAIGIANG,
                ID_KH = kq.ID_KH,
                NOI_DUNG_BAI_GIANG = kq.NOI_DUNG_BAI_GIANG,
                VIDEO = kq.VIDEO,
                PART = kq.PART,
                GIANG_VIEN = kq.GIANG_VIEN,
                TEN_BAI_GIANG = kq.TEN_BAI_GIANG,
                DANH_GIA = kq.DANH_GIA
            };
            return View(item);
        }

        #endregion

        #region Tin Tức

        public ActionResult TinTuc()
        {
            var list_TV = _tinTucDAL.GetList();

            return View(list_TV);
        }

        public ActionResult Add_TinTuc()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add_TinTuc(HttpPostedFileBase upHinh, Model_TinTuc model)
        {
            if (ModelState.IsValid)
            {
                string hinh = UpFile(upHinh, "~/Resource/Image/");
                TIN_TUC item = new TIN_TUC
                {
                    TEN_TIN_TUC = model.TEN_TIN_TUC,
                    NGAY_DANG = DateTime.Now,
                    NOI_DUNG = model.NOI_DUNG,
                    NGUON_TIN_TUC = model.NOI_DUNG,
                    HINH_ANH = hinh
                };
                int kq = _tinTucDAL.Add(item);
                TempData["SuccesMessage"] = "Create SuccessFully";
                return RedirectToAction("TinTuc");
            }
            return View(model);
        }

        public ActionResult Edit_TinTuc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _tinTucDAL.GetDVByMa(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_TinTuc(HttpPostedFileBase UpHinh, TIN_TUC model)
        {
            string hinh = UpFile(UpHinh, "~/Resource/Image/");
            model.HINH_ANH = hinh;
            int kq = _tinTucDAL.Update(model);
            TempData["SuccesMessage"] = "Save SuccessFully";
            return RedirectToAction("TinTuc");
        }

        public ActionResult Delete_TinTuc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int kq = _tinTucDAL.Delete(id);
            TempData["SuccesMessage"] = "Delete SuccessFully";
            return RedirectToAction("TinTuc");
        }

        #endregion
    }
}