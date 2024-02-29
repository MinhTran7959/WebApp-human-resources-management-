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
    public class Proc_KyHDController : Controller
    {
        // GET: Proc_KyHD
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index()
        {
            List<ToanBoDanhSachKyHDResult> dsKyHD = context.ToanBoDanhSachKyHD().ToList();
            return View(dsKyHD);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            TempData["AllMaHD"] = context.ToanBoDanhSachHopDong().ToList();
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(KYHD khd)
        {
            var ct = new QLNSDataContext();
            ct.AddKyHD(Convert.ToInt32(khd.MaHD), Convert.ToInt32(khd.MaNV), Convert.ToDateTime(khd.NgayKy));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            KYHD khd = context.KYHDs.FirstOrDefault(x => x.id == id);
            if (khd != null)
            {
                context.DeleteKyHD(khd.id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidKyHDResult khd = con.GetidKyHD(id).FirstOrDefault();
            return View(khd);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidKyHDResult khd = con.GetidKyHD(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                
                int MaHD = int.Parse(Request.Form["MaHD"]);
                int MaNV = int.Parse(Request.Form["MaNV"]);
                DateTime NgayKy = DateTime.Parse(Request.Form["NgayKy"]);
                con.EditKyHD(khd.id, MaHD,MaNV,NgayKy);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(khd);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From KYHD";
            DataTable dt = new DataTable();
            dt.TableName = "KYHD";
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
                Response.AddHeader("content-disposition", "attachment;filename= KyHDReport.xlsx");

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