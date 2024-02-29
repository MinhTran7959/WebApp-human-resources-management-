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
    public class Proc_LuongController : Controller
    {
        // GET: Proc_Luong
        QLNSDataContext context = new QLNSDataContext();
        
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachLuongResult> dsL = context.ToanBoDanhSachLuong().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsL = context.ToanBoDanhSachLuong().Where(x => x.MucLuongCB.Contains(searchString)).ToList();
            }
            return View(dsL);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LUONG l)
        {
            var ct = new QLNSDataContext();
            ct.AddLuong(l.MucLuongCB);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            LUONG l = context.LUONGs.FirstOrDefault(x => x.MaLuong == id);
            if (l != null)
            {
                context.DeleteLuong(l.MaLuong);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaLuongResult L = con.GetMaLuong(id).FirstOrDefault();
            return View(L);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaLuongResult l = con.GetMaLuong(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string MucLuongCB = Request.Form["MucLuongCB"];
                con.EditLuong(l.MaLuong, MucLuongCB);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(l);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From LUONG";
            DataTable dt = new DataTable();
            dt.TableName = "LUONG";
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
                Response.AddHeader("content-disposition", "attachment;filename= LuongReport.xlsx");

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