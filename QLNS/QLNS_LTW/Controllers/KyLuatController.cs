using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class KyLuatController : Controller
    {
        public ActionResult Index()
        {
            QLNSDataContext ctx = new QLNSDataContext();
            List<KYLUAT> listKL = ctx.KYLUATs.ToList();
            return View(listKL);
        }

        // GET: Kỹ luật/Details/5
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.KYLUATs.Single(x => x.MaKL == id);
            return View(data);

        }

        // GET: Kỹ Luật/Create
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                DateTime ThoiGian = DateTime.Parse(Request.Form["ThoiGian"]);
                String QuyetDinh = Request.Form["QuyetDinh"];
                string Sotienphat = Request.Form["SoTien"];
                int MaNV = int.Parse(Request.Form["MaNV"]);


                QLNSDataContext ctx = new QLNSDataContext();
                KYLUAT kl = new KYLUAT();

                kl.ThoiGian = ThoiGian;
                kl.QuyetDinh = QuyetDinh;
                kl.Sotienphat = Sotienphat;
                kl.MaNV = MaNV;


                ctx.KYLUATs.InsertOnSubmit(kl);
                ctx.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        // GET: Kỹ Luật/Edit/5
        public ActionResult Edit(int id)
        {
            var ctx = new QLNSDataContext();
            var data = ctx.KYLUATs.Single(x => x.MaKL == id);
            return View(data);
        }

        // POST: Kỹ Luật/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KYLUAT collection)
        {
            try
            {
                var context = new QLNSDataContext();
                KYLUAT kl = context.KYLUATs.Single(x => x.MaKL == id);

                kl.ThoiGian = collection.ThoiGian;
                kl.QuyetDinh = collection.QuyetDinh;
                kl.Sotienphat = collection.Sotienphat;
                kl.MaNV = collection.MaNV;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kỹ Luật/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.KYLUATs.Single(x => x.MaKL == id);
            return View(databyid);
        }

        // POST: Kỹ Luật/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KYLUAT collection)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.KYLUATs.Single(x => x.MaKL == id);
                context.KYLUATs.DeleteOnSubmit(data);
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