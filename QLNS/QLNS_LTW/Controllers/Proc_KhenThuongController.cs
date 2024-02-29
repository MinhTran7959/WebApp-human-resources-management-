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
    public class Proc_KhenThuongController : Controller
    {
        // GET: Proc_KhenThuong
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachKhenThuongResult> dsKT = context.ToanBoDanhSachKhenThuong().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsKT = context.ToanBoDanhSachKhenThuong().Where(x => x.QuyetDinh.Contains(searchString)).ToList();
            }
            return View(dsKT);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(KHENTHUONG kt)
        {
            var ct = new QLNSDataContext();
            ct.AddKhenThuong(Convert.ToDateTime(kt.ThoiGian), kt.QuyetDinh, kt.Sotienthuong, Convert.ToInt32(kt.MaNV));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            KHENTHUONG kt = context.KHENTHUONGs.FirstOrDefault(x => x.MaKT == id);
            if (kt != null)
            {
                context.DeleteKhenThuong(kt.MaKT);
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaKTResult makt = con.GetMaKT(id).FirstOrDefault();
            return View(makt);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            TempData["AllMaNV"] = context.GetMaKT(id).ToList();
            GetMaKTResult KT = con.GetMaKT(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                //int maNV;
                int MaKT = Convert.ToInt32(Request.Form["MaKT"]);
                
                DateTime ThoiGian = DateTime.Parse(Request.Form["ThoiGian"]);
                string QuyetDinh = Request.Form["QuyetDinh"];
                string SoTienThuong = Request.Form["SoTienThuong"];
                int MaNV = Convert.ToInt32(Request.Form["MaNV"]);
                con.EditKhenThuong(KT.MaKT, ThoiGian, QuyetDinh, SoTienThuong,MaNV);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(KT);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From KHENTHUONG";
            DataTable dt = new DataTable();
            dt.TableName = "KHENTHUONG";
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
                Response.AddHeader("content-disposition", "attachment;filename= KhenThuongReport.xlsx");

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