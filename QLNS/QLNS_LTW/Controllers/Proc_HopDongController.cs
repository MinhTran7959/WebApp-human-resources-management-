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
    public class Proc_HopDongController : Controller
    {
        // GET: Proc_HopDong
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachHopDongResult> dsHD = context.ToanBoDanhSachHopDong().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsHD = context.ToanBoDanhSachHopDong().Where(x => x.TenHD.Contains(searchString)).ToList();
            }
            return View(dsHD);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HOPDONG hd)
        {
            var ct = new QLNSDataContext();
            ct.AddHopDong(hd.ViTri,hd.LoaiHD, hd.ThoiHan,hd.TenHD);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HOPDONG hd = context.HOPDONGs.FirstOrDefault(x => x.MaHD == id);
            if (hd != null)
            {
                context.DeleteHopDong(hd.MaHD);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaHDResult mahd = con.GetMaHD(id).FirstOrDefault();
            return View(mahd);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaHDResult hd = con.GetMaHD(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string ViTri = Request.Form["ViTri"];
                string LoaiHD = Request.Form["LoaiHD"];
                string ThoiHan = Request.Form["ThoiHan"];
                string TenHD = Request.Form["TenHD"];
                con.EditHopDong(hd.MaHD, ViTri, LoaiHD, ThoiHan, TenHD);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(hd);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From HOPDONG";
            DataTable dt = new DataTable();
            dt.TableName = "HOPDONG";
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
                Response.AddHeader("content-disposition", "attachment;filename= HopDongReport.xlsx");

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