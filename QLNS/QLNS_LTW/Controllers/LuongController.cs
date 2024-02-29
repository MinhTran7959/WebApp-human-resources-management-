using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class LuongController : Controller
    {
        // GET: Luong
        public ActionResult Index()
        {
            QLNSDataContext ctx = new QLNSDataContext();
            List<LUONG> listL = ctx.LUONGs.ToList();
            return View(listL);
        }

        // GET: Lương/Details/5
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.LUONGs.Single(x => x.MaLuong == id);
            return View(data);

        }

        // GET: Lương/Create
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                
               String MucLuongCB = Request.Form["MucLuongCB"];

                QLNSDataContext ctx = new QLNSDataContext();
                LUONG l = new LUONG();
                
                l.MucLuongCB = MucLuongCB;

                ctx.LUONGs.InsertOnSubmit(l);
                ctx.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        // GET: Lương/Edit/5
        public ActionResult Edit(int id)
        {
            var ctx = new QLNSDataContext();
            var data = ctx.LUONGs.Single(x => x.MaLuong == id);
            return View(data);
        }

        // POST: Luong/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LUONG collection)
        {
            try
            {
                var context = new QLNSDataContext();
                LUONG l = context.LUONGs.Single(x => x.MaLuong == id);

                l.MucLuongCB = collection.MucLuongCB;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lương/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.LUONGs.Single(x => x.MaLuong == id);
            return View(databyid);
        }

        // POST: Lương/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LUONG collection)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.LUONGs.Single(x => x.MaLuong == id);
                context.LUONGs.DeleteOnSubmit(data);
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