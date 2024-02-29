using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QLNS_LTW.Controllers
{
    [Authorize]
    public class QuaTrinhLuongController : Controller
    {
        // GET: QuaTrinhLuong
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<QUATRINHLUONG> listQTL = context.QUATRINHLUONGs.ToList();

            return View(listQTL);
        }

        //Tạo create QTL
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                
                int MaNV = int.Parse(Request.Form["MaNV"]);
                int MaLuong = int.Parse(Request.Form["MaLuong"]);
                int MaPB = int.Parse(Request.Form["MaPB"]);
                int MaCV = int.Parse(Request.Form["MaCV"]);
                DateTime TGBD = DateTime.Parse(Request.Form["TGBD"]);
                DateTime TGKT = DateTime.Parse(Request.Form["TGKT"]);

                QLNSDataContext context = new QLNSDataContext();
                QUATRINHLUONG qtl = new QUATRINHLUONG();
                qtl.MaNV = MaNV;
                qtl.MaLuong = MaLuong;
                qtl.MaPB = MaPB;
                qtl.MaCV = MaCV;
                qtl.TGBD = TGBD;
                qtl.TGKT = TGKT;

                context.QUATRINHLUONGs.InsertOnSubmit(qtl);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        //Get edit QTL  
        public ActionResult Edit(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHLUONGs.Single(x => x.id == id);

            return View(data);
        }

        //Post edit QTL
        [HttpPost]
        public ActionResult Edit(int id, QUATRINHLUONG collection)
        {
            try
            {
                var context = new QLNSDataContext();
                QUATRINHLUONG  qtl = new QUATRINHLUONG();
                qtl.MaNV = collection.MaNV;
                qtl.MaLuong = collection.MaLuong;
                qtl.MaPB = collection.MaPB;
                qtl.MaCV = collection.MaCV;
                qtl.TGBD = collection.TGBD;
                qtl.TGKT = collection.TGKT;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //Get Details qtl
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHLUONGs.Single(x => x.id == id);
            return View(data);
        }

        //Get Delete qtl
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHLUONGs.Single(x => x.id == id);
            return View(data);
        }

        //Post delete qtl
        [HttpPost]
        public ActionResult Delete(int id, PHONGBAN col)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.QUATRINHLUONGs.Single(x => x.id == id);
                context.QUATRINHLUONGs.DeleteOnSubmit(data);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}