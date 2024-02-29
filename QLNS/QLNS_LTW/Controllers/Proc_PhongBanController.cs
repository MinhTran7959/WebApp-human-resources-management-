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
    public class Proc_PhongBanController : Controller
    {
        // GET: Proc_PhongBan
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachPhongBanResult> dsPB = context.ToanBoDanhSachPhongBan().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsPB = context.ToanBoDanhSachPhongBan().Where(x => x.TenPB.Contains(searchString)).ToList();
            }
            return View(dsPB);
        }

        [ValidateInput(true)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PHONGBAN pb)
        {
            var ct = new QLNSDataContext();
            ct.AddPhongBan(pb.TenPB);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            PHONGBAN pb = context.PHONGBANs.FirstOrDefault(x => x.MaPB == id);
            if (pb != null)
            {
                context.DeletePhongBan(pb.MaPB);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaPBResult khd = con.GetMaPB(id).FirstOrDefault();
            return View(khd);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetMaPBResult pb = con.GetMaPB(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                //int maNV;
                int MaPB = Convert.ToInt32(Request.Form["MaPB"]);
                string TenPB = Request.Form["TenPB"];
                


                con.EditPhongBan(pb.MaPB, TenPB);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(pb);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From PHONGBAN";
            DataTable dt = new DataTable();
            dt.TableName = "PHONGBAN";
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
                Response.AddHeader("content-disposition", "attachment;filename= PhongBanReport.xlsx");

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