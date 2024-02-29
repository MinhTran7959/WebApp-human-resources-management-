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
    public class Proc_QuaTrinhChucVuController : Controller
    {
        // GET: Proc_QuaTrinhChucVu
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index()
        {
            List<ToanBoDanhSachQTCVResult> dsQTCV = context.ToanBoDanhSachQTCV().ToList();
            return View(dsQTCV);
        }

        public ActionResult Create()
        {
            TempData["AllMaCV"] = context.ToanBoDanhSachChucVu().ToList();
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(QUATRINHCHUCVU qtcv)
        {
            var ct = new QLNSDataContext();
            ct.AddQTCV(Convert.ToInt32(qtcv.MaCV), Convert.ToInt32(qtcv.MaNV), Convert.ToDateTime(qtcv.TGBD), Convert.ToDateTime(qtcv.TGKT));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            QUATRINHCHUCVU qtcv = context.QUATRINHCHUCVUs.FirstOrDefault(x => x.id == id);
            if (qtcv != null)
            {
                context.DeleteQTCV(qtcv.id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidQTCVResult qtcv = con.GetidQTCV(id).FirstOrDefault();
            return View(qtcv);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidQTCVResult qtcv = con.GetidQTCV(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {

                int MaCV = int.Parse(Request.Form["MaCV"]);
                int MaNV = int.Parse(Request.Form["MaNV"]);
                DateTime TGBD = DateTime.Parse(Request.Form["TGBD"]);
                DateTime TGKT = DateTime.Parse(Request.Form["TGKT"]);
                con.EditQTCV(qtcv.id, MaCV, MaNV, TGBD,TGKT);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(qtcv);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From QUATRINHCHUCVU";
            DataTable dt = new DataTable();
            dt.TableName = "QUATRINHCHUCVU";
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
                Response.AddHeader("content-disposition", "attachment;filename= QuaTrinhChucVuReport.xlsx");

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