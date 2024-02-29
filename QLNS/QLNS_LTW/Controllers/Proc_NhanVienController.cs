using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS_LTW.Models;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QLNS_LTW.Controllers
{
    [Authorize]
    public class Proc_NhanVienController : Controller
    {
        // GET: Proc_NhanVien
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index(string searchString)
        {
            
            List<ToanBoDanhSachNhanVienResult> dsNV = context.ToanBoDanhSachNhanVien().ToList();
            
            if(!string.IsNullOrEmpty(searchString))
            {
                dsNV = context.ToanBoDanhSachNhanVien().Where(x => x.Hoten.Contains(searchString)).ToList();
            }
            return View(dsNV);
        }


        [ValidateInput(true)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHANVIEN nv)
        {
            var ct = new QLNSDataContext();
            ct.AddNhanVien(nv.Hoten, nv.Email, nv.SDT, nv.CCCD, nv.Noisinh, Convert.ToDateTime(nv.Ngaysinh), nv.Gioitinh, nv.Diachi);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            NHANVIEN nv = context.NHANVIENs.FirstOrDefault(x => x.MaNV == id);
            if (nv != null)
            {
                context.DeleteNhanVien(nv.MaNV);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaNVResult khd = con.GetMaNV(id).FirstOrDefault();
            return View(khd);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaNVResult nv = con.GetMaNV(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string HoTen = Request.Form["HoTen"];
                string Email = Request.Form["Email"];
                string SDT = Request.Form["SDT"];
                string CCCD = Request.Form["CCCD"];
                string NoiSinh = Request.Form["NoiSinh"];
                DateTime NgaySinh = DateTime.Parse(Request.Form["NgaySinh"]);
                string GioiTinh = Request.Form["GioiTinh"];
                string DiaChi = Request.Form["DiaChi"];


                con.EditNhanVien(nv.MaNV, HoTen, Email, SDT, CCCD, NoiSinh, NgaySinh, GioiTinh, DiaChi);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(nv);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From NHANVIEN";
            DataTable dt = new DataTable();
            dt.TableName = "NHANVIEN";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= NhanVienReport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            return RedirectToAction("Index");
        }
    }
}