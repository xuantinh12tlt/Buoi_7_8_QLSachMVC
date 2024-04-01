using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.NetFrameWork;
using DataAccess.NetFrameWork.Interface;
using Buoi_7_8_QuanLySachMVC.Models;



namespace QLSachMVC.Controllers
{
    public class HomeController : Controller
    {
        List<Sach> lstSach = new List<Sach>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public JsonResult SachThemSachMoi(SachModel requestData)
        {
            try
            {
                string sError = "1";
                if (requestData == null || (string.IsNullOrEmpty(requestData.MaSach) || string.IsNullOrEmpty(requestData.TenSach) || string.IsNullOrEmpty(requestData.DonGia)))
                {
                    if (requestData == null)
                        sError = "-1";
                    if (string.IsNullOrEmpty(requestData.MaSach))
                        sError = "-2";
                    if (string.IsNullOrEmpty(requestData.TenSach))
                        sError = "-3";
                    if (!CommonLibs.DataValidity.CheckIsNumber(requestData.DonGia))
                    {
                        sError = "-4";
                    }
                    return Json(sError, JsonRequestBehavior.AllowGet);
                    //return requestData.;
                }
                var req = new DataAccess.NetFrameWork.Sach
                {
                    MaSach = requestData.MaSach,
                    TenSach = requestData.TenSach,
                    DonGia = decimal.Parse(requestData.DonGia)
                };
                //var result = new DataAccess.NetFrameWork.Interface.QuanLySach().ThemSachMoi(lstSach, req);
                //var result = new DataAccess.NetFrameWork.Interface.QuanLySach().ThemSachMoi(req);
                //KhoLuuTruSach.Add(req);
                //lstSach = KhoLuuTruSach.ListSach();
                lstSach = QuanLySach.HienThiThongTinSach();
                var dtTrungMaSach = lstSach.AsEnumerable().Where(p => p.MaSach == req.MaSach);
                if (dtTrungMaSach.Any())
                {
                    //sError = "=-5";
                    foreach (var sach in dtTrungMaSach)
                    {
                        int iCapNhatSach = QuanLySach.CapNhatThongTinSach(req);
                        lstSach = QuanLySach.HienThiThongTinSach();
                    }

                    return Json(lstSach, JsonRequestBehavior.AllowGet);

                }
                int iAddSach = QuanLySach.ThemSachMoi(req);
                lstSach = QuanLySach.HienThiThongTinSach();
                if (iAddSach == 0)
                {
                    sError = "0";
                    return Json(sError, JsonRequestBehavior.AllowGet);
                }
                return Json(lstSach, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult EditSach(string id)
        {
            try
            {
                lstSach = QuanLySach.HienThiThongTinSach().Where(p => p.MaSach == id).ToList();
                return Json(lstSach, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteSach(string id)
        {
            try
            {
                lstSach = QuanLySach.HienThiThongTinSach().Where(p => p.MaSach == id).ToList();
                if (lstSach.Any())
                {
                    foreach (var itemSach in lstSach)
                    {
                        QuanLySach.XoaSach(itemSach);
                        lstSach = QuanLySach.HienThiThongTinSach();
                    }
                }

                return Json(lstSach, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}