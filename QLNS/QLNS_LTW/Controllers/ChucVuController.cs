using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class ChucVuController : Controller
    {
        // GET: ChucVu
        public ActionResult Index()
        {
            QLNSDataContext ctx = new QLNSDataContext();
            List<CHUCVU> listCV = ctx.CHUCVUs.ToList();
            return View(listCV);
        }

        // GET: ChucVu/Details/5
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.CHUCVUs.Single(x => x.MaCV == id);
            return View(data);
            
        }

        // GET: ChucVu/Create
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                String TenCV = Request.Form["TenCV"];
                //decimal PhuCap = decimal.Parse(Request.Form["PhuCap"]);

                QLNSDataContext ctx = new QLNSDataContext();
                CHUCVU cv = new CHUCVU();
                cv.TenCV = TenCV;
                //cv.PhuCap = PhuCap;
                
                ctx.CHUCVUs.InsertOnSubmit(cv);
                ctx.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        

        // GET: ChucVu/Edit/5
        public ActionResult Edit(int id)
        {
            var ctx = new QLNSDataContext();
            var data = ctx.CHUCVUs.Single(x => x.MaCV == id);
            return View(data);
        }

        // POST: ChucVu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CHUCVU collection)
        {
            try
            {
                var context = new QLNSDataContext();
                CHUCVU cv = context.CHUCVUs.Single(x => x.MaCV == id);
                cv.TenCV = collection.TenCV;

                
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // GET: ChucVu/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.CHUCVUs.Single(x => x.MaCV == id);
            return View(databyid);
        }

        // POST: ChucVu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CHUCVU collection)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.CHUCVUs.Single(x => x.MaCV == id);
                context.CHUCVUs.DeleteOnSubmit(data);
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
