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
    public class Proc_KyLuatController : Controller
    {
        // GET: Proc_KyLuat
        QLNSDataContext context = new QLNSDataContext();
        
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachKyLuatResult> dsKL = context.ToanBoDanhSachKyLuat().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsKL = context.ToanBoDanhSachKyLuat().Where(x => x.QuyetDinh.Contains(searchString)).ToList();
            }
            return View(dsKL);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(KYLUAT kl)
        {
            var ct = new QLNSDataContext();
            ct.AddKyLuat(Convert.ToDateTime(kl.ThoiGian), kl.QuyetDinh, kl.Sotienphat, Convert.ToInt32(kl.MaNV));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            KYLUAT kl = context.KYLUATs.FirstOrDefault(x => x.MaKL == id);
            if (kl != null)
            {
                context.DeleteKyLuat(kl.MaKL);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaKLResult KL = con.GetMaKL(id).FirstOrDefault();
            return View(KL);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            TempData["AllMaNV"] = context.GetMaKL(id).ToList();
            GetMaKLResult kl = con.GetMaKL(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                DateTime ThoiGian = DateTime.Parse(Request.Form["ThoiGian"]);
                string QuyetDinh = Request.Form["QuyetDinh"];  
                string Sotienphat = Request.Form["Sotienphat"];
                int MaNV = int.Parse(Request.Form["MaNV"]);
                con.EditKyLuat(kl.MaKL, ThoiGian, QuyetDinh,Sotienphat,MaNV);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(kl);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From KYLUAT";
            DataTable dt = new DataTable();
            dt.TableName = "KYLUAT";
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
                Response.AddHeader("content-disposition", "attachment;filename= KyLuatReport.xlsx");

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