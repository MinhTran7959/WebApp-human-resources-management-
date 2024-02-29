using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class QuaTrinhCongTacController : Controller
    {
        // GET: QuaTrinhCongTac
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<QUATRINHCONGTAC> listQTCT = context.QUATRINHCONGTACs.ToList();

            return View(listQTCT);
        }

        //Tạo create QTCT
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                
                int MaNV = int.Parse(Request.Form["MaNV"]);
                int MaPB = int.Parse(Request.Form["MaPB"]);
                DateTime TGBD = DateTime.Parse(Request.Form["TGBD"]);
                DateTime TGKT = DateTime.Parse(Request.Form["TGKT"]);

                QLNSDataContext context = new QLNSDataContext();
                QUATRINHCONGTAC qtct = new QUATRINHCONGTAC();
                qtct.MaNV = MaNV;
                qtct.MaPB = MaPB;
                qtct.TGBD = TGBD;
                qtct.TGKT = TGKT;

                context.QUATRINHCONGTACs.InsertOnSubmit(qtct);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        //Get edit qtct
        public ActionResult Edit(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHCONGTACs.Single(x => x.id == id);

            return View(data);
        }

        //Post edit qtct
        [HttpPost]
        public ActionResult Edit(int id, QUATRINHCONGTAC collection)
        {
            try
            {
                var context = new QLNSDataContext();
                QUATRINHCONGTAC qtct = new QUATRINHCONGTAC();
                qtct.MaNV = collection.MaNV;
                qtct.MaPB = collection.MaPB;
                qtct.TGBD = collection.TGBD;
                qtct.TGKT = collection.TGKT;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //Get Details qtct
        public ActionResult Details(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHCONGTACs.Single(x => x.id == id);
            return View(data);
        }

        //Get Delete qtct
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var data = context.QUATRINHCONGTACs.Single(x => x.id == id);
            return View(data);
        }

        //Post delete qtct
        [HttpPost]
        public ActionResult Delete(int id, QUATRINHCONGTAC col)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.QUATRINHCONGTACs.Single(x => x.id == id);
                context.QUATRINHCONGTACs.DeleteOnSubmit(data);
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