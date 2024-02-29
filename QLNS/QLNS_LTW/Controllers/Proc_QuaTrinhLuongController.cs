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
    public class Proc_QuaTrinhLuongController : Controller
    {
        // GET: Proc_QuaTrinhLuong
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index()
        {
            List<ToanBoDanhSachQTLResult> dsQTL = context.ToanBoDanhSachQTL().ToList();
            return View(dsQTL);
        }
        [ValidateInput(true)]
        public ActionResult Create()
        {
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            TempData["AllMaLuong"] = context.ToanBoDanhSachLuong().ToList();
            TempData["AllMaPB"] = context.ToanBoDanhSachPhongBan().ToList();
            TempData["AllMaCV"] = context.ToanBoDanhSachChucVu().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(QUATRINHLUONG qtl)
        {
            var ct = new QLNSDataContext();
            ct.AddQTL(Convert.ToInt32(qtl.MaNV), Convert.ToInt32(qtl.MaLuong), Convert.ToInt32(qtl.MaPB), Convert.ToInt32(qtl.MaCV), Convert.ToDateTime(qtl.TGBD), Convert.ToDateTime(qtl.TGKT));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            QUATRINHLUONG qtl = context.QUATRINHLUONGs.FirstOrDefault(x => x.id == id);
            if (qtl != null)
            {
                context.DeleteQTL(qtl.id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidQTLResult qtl = con.GetidQTL(id).FirstOrDefault();
            return View(qtl);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidQTLResult qtl = con.GetidQTL(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {

                
                int MaNV = int.Parse(Request.Form["MaNV"]);
                int MaLuong = int.Parse(Request.Form["MaLuong"]);
                int MaPB = int.Parse(Request.Form["MaPB"]);
                int MaCV = int.Parse(Request.Form["MaCV"]);
                DateTime TGBD = DateTime.Parse(Request.Form["TGBD"]);
                DateTime TGKT = DateTime.Parse(Request.Form["TGKT"]);
                con.EditQTL(qtl.id, MaNV, MaLuong,MaPB,MaCV,TGBD,TGKT);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(qtl);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From QUATRINHLUONG";
            DataTable dt = new DataTable();
            dt.TableName = "QUATRINHLUONG";
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
                Response.AddHeader("content-disposition", "attachment;filename= QuaTrinhLuonhReport.xlsx");

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