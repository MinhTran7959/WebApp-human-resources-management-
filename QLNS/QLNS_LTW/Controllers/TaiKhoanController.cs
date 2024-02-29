using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;


namespace QLNS_LTW.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            QLNSDataContext ctx = new QLNSDataContext();
            List<TAIKHOAN> listTK = ctx.TAIKHOANs.ToList();
            return View(listTK);
        }

        // GET: taikhoan/Details/5
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.TAIKHOANs.Single(x => x.id == id);
            return View(data);

        }

        // GET: taikhoan/Create
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                int MaNV = int.Parse(Request.Form["MaNV"]);
                String TaiKhoan = Request.Form["TaiKhoan"];
                String MatKhau = Request.Form["MatKhau"];
                string LaQuanTri = Request.Form["LaQuanTri"];



                QLNSDataContext ctx = new QLNSDataContext();
                TAIKHOAN tk = new TAIKHOAN();

                tk.MaNV = MaNV;
                tk.TaiKhoan = TaiKhoan;
                tk.MatKhau = MatKhau; ;
                tk.LaQuanTri = LaQuanTri;



                ctx.TAIKHOANs.InsertOnSubmit(tk);
                ctx.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        // GET: taikhoan /Edit/5
        public ActionResult Edit(int id)
        {
            var ctx = new QLNSDataContext();
            var data = ctx.TAIKHOANs.Single(x => x.id == id);
            return View(data);
        }

        // POST: taikhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TAIKHOAN collection)
        {
            try
            {
                var context = new QLNSDataContext();
                TAIKHOAN tk = context.TAIKHOANs.Single(x => x.id == id);

                tk.MaNV = collection.MaNV;
                tk.TaiKhoan=collection.TaiKhoan;
                tk.MatKhau=collection.MatKhau;
                tk.LaQuanTri = collection.LaQuanTri;


                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: taikhoan/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.TAIKHOANs.Single(x => x.id == id);
            return View(databyid);
        }

        // POST: taikhoan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TAIKHOAN collection)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.TAIKHOANs.Single(x => x.id == id);
                context.TAIKHOANs.DeleteOnSubmit(data);
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