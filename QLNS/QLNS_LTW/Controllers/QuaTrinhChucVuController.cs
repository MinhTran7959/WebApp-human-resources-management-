using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class QuaTrinhChucVuController : Controller
    {
        // GET: QuaTrinhChucVu
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<QUATRINHCHUCVU> listQTCV = context.QUATRINHCHUCVUs.ToList();

            return View(listQTCV);
        }

        //Tạo create QTCV
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                int MaCV = int.Parse(Request.Form["MaCV"]);
                int MaNV = int.Parse(Request.Form["MaNV"]);
                DateTime TGBD = DateTime.Parse(Request.Form["TGBD"]);
                DateTime TGKT = DateTime.Parse(Request.Form["TGKT"]);

                QLNSDataContext context = new QLNSDataContext();
                QUATRINHCHUCVU qtcv = new QUATRINHCHUCVU();
                qtcv.MaCV = MaCV;
                qtcv.MaNV = MaNV;
                qtcv.TGBD = TGBD;
                qtcv.TGKT = TGKT;

                context.QUATRINHCHUCVUs.InsertOnSubmit(qtcv);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        //Get edit qtcv
        public ActionResult Edit(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHCHUCVUs.Single(x => x.id == id) ;

            return View(data);
        }

        //Post edit qtcv
        [HttpPost]
        public ActionResult Edit(int id, QUATRINHCHUCVU collection)
        {
            try
            {
                var context = new QLNSDataContext();
                QUATRINHCHUCVU qtcv = new QUATRINHCHUCVU();
                qtcv.MaCV = collection.MaCV;
                qtcv.MaNV = collection.MaNV;
                qtcv.TGBD = collection.TGBD;
                qtcv.TGKT = collection.TGKT;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //Get Details QTCV
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHCHUCVUs.Single(x => x.id == id);
            return View(data);
        }

        //Get Delete QTCV
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHCHUCVUs.Single(x => x.id == id);
            return View(data);
        }

        //Post delete  QTCV
        [HttpPost]
        public ActionResult Delete(int id, QUATRINHCHUCVU col)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.QUATRINHCHUCVUs.Single(x => x.id == id);
                context.QUATRINHCHUCVUs.DeleteOnSubmit(data);
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