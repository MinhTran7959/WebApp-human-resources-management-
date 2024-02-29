using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            QLNSDataContext context = new QLNSDataContext();
            List<NHANVIEN> listNhanVien = context.NHANVIENs.ToList();

            return View(listNhanVien);
        }

        //Thêm dữ liệu
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                
                String Hoten = Request.Form["Hoten"];
                String Email = Request.Form["Email"];
                String SDT = Request.Form["SDT"];
                String CCCD = Request.Form["CCCD"];
                String Noisinh = Request.Form["Noisinh"];
                DateTime Ngaysinh = DateTime.Parse(Request.Form["Ngaysinh"]);
                String Gioitinh = Request.Form["Gioitinh"];
                String Diachi = Request.Form["Diachi"];

                QLNSDataContext context = new QLNSDataContext();
                NHANVIEN nv = new NHANVIEN();
                nv.Hoten = Hoten;
                nv.Email = Email;
                nv.SDT = SDT;
                nv.CCCD = CCCD;
                nv.Noisinh = Noisinh;
                nv.Ngaysinh = Ngaysinh;
                nv.Gioitinh = Gioitinh;
                nv.Diachi = Diachi;

                context.NHANVIENs.InsertOnSubmit(nv);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET edit NHAN VIEN
        public ActionResult Edit(int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.NHANVIENs.Single(x => x.MaNV == id);
            return View(databyid);
        }

        //POST edit NHAN VIÊN
        [HttpPost]
        public ActionResult Edit(int id, NHANVIEN collection)
        {
            try
            {
                var context = new QLNSDataContext();
                NHANVIEN nv = context.NHANVIENs.Single(x => x.MaNV == id);
                nv.Hoten = collection.Hoten;
                nv.Email = collection.Email;
                nv.SDT = collection.SDT;
                nv.CCCD = collection.CCCD;
                nv.Noisinh = collection.Noisinh;
                nv.Ngaysinh = collection.Ngaysinh;
                nv.Diachi = collection.Diachi;

                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }



        public ActionResult Details(int id)
        {
            
            var context = new QLNSDataContext();
            var databyid = context.NHANVIENs.Single(x=> x.MaNV==id);
            return View(databyid);
        }


        //get delete nhân viên
        public ActionResult Delete (int id)
        {
            var context = new QLNSDataContext();
            var databyid = context.NHANVIENs.Single(x => x.MaNV == id);
            return View(databyid);
        }

        //POST DELETE NHÂN VIÊN
        [HttpPost]
        public ActionResult Delete(int id, NHANVIEN collection)
        {
            try
            {
                var context = new QLNSDataContext();
                var data = context.NHANVIENs.Single(x => x.MaNV == id);
                context.NHANVIENs.DeleteOnSubmit(data);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }








    }

    
}