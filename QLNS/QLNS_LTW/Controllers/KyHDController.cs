using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class KyHDController : Controller
    {
        // GET: KyHD
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<KYHD> listKHD = context.KYHDs.ToList();

            return View(listKHD);
        }

        //Tạo create kyHD
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {

                int MaHD = int.Parse(Request.Form["MaHD"]);
                int MaNV = int.Parse(Request.Form["MaNV"]);
                DateTime NgayKy = DateTime.Parse(Request.Form["NgayKy"]);

                QLNSDataContext context = new QLNSDataContext();
                KYHD khd = new KYHD();
                khd.MaHD = MaHD;
                khd.MaNV = MaNV;
                khd.NgayKy = NgayKy;

                context.KYHDs.InsertOnSubmit(khd);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        //Get edit kyHD
        public ActionResult Edit(int id)
        {
            var context = new QLNSDataContext();
            var data = context.KYHDs.Single(x => x.id == id);

            return View(data);
        }

        //Post edit KyHD
        [HttpPost]
        public ActionResult Edit(int id, KYHD collection)
        {
            try
            {
                var context = new QLNSDataContext();
                KYHD khd = new KYHD();
                khd.MaHD = collection.MaHD;
                khd.MaNV = collection.MaNV;
                khd.NgayKy = collection.NgayKy;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //Get Details kyHD
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.KYHDs.Single(x => x.id == id);
            return View(data);
        }

        //Get Delete kyHd
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var data = context.KYHDs.Single(x => x.id == id);
            return View(data);
        }

        //Post delete kyHD
        [HttpPost]
        public ActionResult Delete(int id, KYHD col)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.KYHDs.Single(x => x.id == id);
                context.KYHDs.DeleteOnSubmit(data);
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