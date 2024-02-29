using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class HopDongController : Controller
    {
        // GET: HopDong
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<HOPDONG> listHD = context.HOPDONGs.ToList();

            return View(listHD);
        }

        //Tạo create hopdong
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                String ViTri = Request.Form["ViTri"];
                String LoaiHD = Request.Form["LoaiHD"];
                String ThoiHan = Request.Form["ThoiHan"];
                String TenHD = Request.Form["TenHD"];




                QLNSDataContext context = new QLNSDataContext();
                HOPDONG hd = new HOPDONG();
                hd.ViTri = ViTri;
                hd.LoaiHD = LoaiHD;
                hd.ThoiHan = ThoiHan;
                hd.TenHD = TenHD;

                context.HOPDONGs.InsertOnSubmit(hd);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        //Get edit hopdong
        public ActionResult Edit(int id)
        {
            var context = new QLNSDataContext();
            var data = context.HOPDONGs.Single(x => x.MaHD == id);

            return View(data);
        }

        //Post edit hopdong
        [HttpPost]
        public ActionResult Edit(int id, HOPDONG collection)
        {
            try
            {
                var context = new QLNSDataContext();
                HOPDONG hd = new HOPDONG();
                hd.ViTri = collection.ViTri;
                hd.LoaiHD = collection.LoaiHD;
                hd.ThoiHan = collection.ThoiHan;
                hd.TenHD = collection.TenHD;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //Get Details hopdong
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.HOPDONGs.Single(x => x.MaHD == id);
            return View(data);
        }

        //Get Delete hopdong
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var data = context.HOPDONGs.Single(x => x.MaHD == id);
            return View(data);
        }

        //Post delete hopdong
        [HttpPost]
        public ActionResult Delete(int id, HOPDONG col)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.HOPDONGs.Single(x => x.MaHD == id);
                context.HOPDONGs.DeleteOnSubmit(data);
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