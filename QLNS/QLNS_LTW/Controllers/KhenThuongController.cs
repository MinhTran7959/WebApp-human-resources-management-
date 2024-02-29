using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class KhenThuongController : Controller
    {
        // GET: KhenThuong
        public ActionResult Index()
        {
            QLNSDataContext ctx = new QLNSDataContext();
            List<KHENTHUONG> listKT = ctx.KHENTHUONGs.ToList();
            return View(listKT);
        }

        // GET: KhenThuong/Details/5
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.KHENTHUONGs.Single(x => x.MaKT == id);
            return View(data);

        }

        // GET: KhenThuong/Create
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                DateTime ThoiGian = DateTime.Parse(Request.Form["ThoiGian"]);
                String QuyetDinh = Request.Form["QuyetDinh"];
                string Sotienthuong = Request.Form["Sotienthuong"];
                int MaNV = int.Parse(Request.Form["MaNV"]);


                QLNSDataContext ctx = new QLNSDataContext();
                KHENTHUONG kt = new KHENTHUONG();

                kt.ThoiGian = ThoiGian;
                kt.QuyetDinh = QuyetDinh;
                kt.Sotienthuong = Sotienthuong;
                kt.MaNV = MaNV;


                ctx.KHENTHUONGs.InsertOnSubmit(kt);
                ctx.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        // GET: Khen Thưởng/Edit/5
        public ActionResult Edit(int id)
        {
            var ctx = new QLNSDataContext();
            var data = ctx.KHENTHUONGs.Single(x => x.MaKT == id);
            return View(data);
        }

        // POST: Khen Thưởng/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KHENTHUONG collection)
        {
            try
            {
                var context = new QLNSDataContext();
                KHENTHUONG kt = context.KHENTHUONGs.Single(x => x.MaKT == id);

                kt.ThoiGian = collection.ThoiGian;
                kt.QuyetDinh = collection.QuyetDinh;
                kt.Sotienthuong = collection.Sotienthuong;
                kt.MaNV= collection.MaNV;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khen Thưởng/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.KHENTHUONGs.Single(x => x.MaKT == id);
            return View(databyid);
        }

        // POST: Khen Thưởng/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KHENTHUONG collection)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.KHENTHUONGs.Single(x => x.MaKT == id);
                context.KHENTHUONGs.DeleteOnSubmit(data);
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