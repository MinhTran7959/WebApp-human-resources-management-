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
    public class Proc_ChucVuController : Controller
    {
        // GET: Proc_ChucVu
        //Lấy toàn bộ danh sách thông qua procedure
        
        QLNSDataContext context = new QLNSDataContext();
        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachChucVuResult> dsTBChucVu = context.ToanBoDanhSachChucVu().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsTBChucVu = context.ToanBoDanhSachChucVu().Where(x => x.TenCV.Contains(searchString)).ToList();
            }
            return View(dsTBChucVu);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CHUCVU c)
        {
            var ct = new QLNSDataContext();
            ct.AddChucVu(c.TenCV);
            return RedirectToAction("Index");
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaCVResult macv = con.GetMaCV(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string TenCV = Request.Form["TenCV"];
                con.EditChucVu(macv.MaCV, TenCV);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(macv);
        }



        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaCVResult macv = con.GetMaCV(id).FirstOrDefault();
            return View(macv);
        }

        public ActionResult Delete(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            CHUCVU cv = con.CHUCVUs.FirstOrDefault(x => x.MaCV == id);
            if (cv != null)
            {
                con.DeleteChucVu(cv.MaCV);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From ChucVu";
            DataTable dt = new DataTable();
            dt.TableName = "ChucVu";
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
                Response.AddHeader("content-disposition", "attachment;filename= ChucVuReport.xlsx");

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