using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;
namespace QLNS_LTW.Controllers
{
    public class PhongBanController : Controller
    {
        // GET: PhongBan
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<PHONGBAN> listPhongBan = context.PHONGBANs.ToList();

            return View(listPhongBan);
        }

        //Tạo create phòng ban
        public ActionResult Create() 
        {
            if(Request.Form.Count > 0)
            {
                String TenPB = Request.Form["TenPB"];


                QLNSDataContext context = new QLNSDataContext();
                PHONGBAN pb = new PHONGBAN();
                pb.TenPB = TenPB;


                context.PHONGBANs.InsertOnSubmit(pb);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            
            
            return View(); 
        }

        //Get edit phòng ban
        public ActionResult Edit(int id) 
        {
            var context = new QLNSDataContext();
            var data = context.PHONGBANs.Single(x => x.MaPB == id);

            return View(data);
        }

        //Post edit phòng ban
        [HttpPost]
        public ActionResult Edit(int id, PHONGBAN collection)
        {
            try
            {
                var context = new QLNSDataContext();
                PHONGBAN pb = new PHONGBAN();
                pb.MaPB = collection.MaPB;
                pb.TenPB=collection.TenPB;
               

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
        
        //Get Details phòng ban
        public ActionResult Details(int id) 
        { 
            var context = new QLNSDataContext();
            var data= context.PHONGBANs.Single(x => x.MaPB==id);
            return View(data); 
        }

        //Get Delete phòng ban
        public ActionResult Delete(int id)
        {
            var context = new QLNSDataContext();
            var data=context.PHONGBANs.Single(x => x.MaPB==id);
            return View(data);
        }

        //Post delete phòng ban
        [HttpPost]
        public ActionResult Delete(int id, PHONGBAN col) 
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.PHONGBANs.Single(x => x.MaPB==id);
                context.PHONGBANs.DeleteOnSubmit(data);
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