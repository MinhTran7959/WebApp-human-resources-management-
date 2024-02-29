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
    public class Proc_QuaTrinhCongTacController : Controller
    {
        // GET: Proc_QuaTrinhCongTac
        QLNSDataContext context = new QLNSDataContext();
        public ActionResult Index()
        {
            List<ToanBoDanhSachQTCTResult> dsQTCT = context.ToanBoDanhSachQTCT().ToList();
            return View(dsQTCT);
        }
        [ValidateInput(true)]
        public ActionResult Create()
        {
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            TempData["AllMaPB"] = context.ToanBoDanhSachPhongBan().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(QUATRINHCONGTAC qtct)
        {
            var ct = new QLNSDataContext();
            ct.AddQTCT(Convert.ToInt32(qtct.MaNV), Convert.ToInt32(qtct.MaPB), Convert.ToDateTime(qtct.TGBD), Convert.ToDateTime(qtct.TGKT));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            QUATRINHCONGTAC qtct = context.QUATRINHCONGTACs.FirstOrDefault(x => x.id == id);
            if (qtct != null)
            {
                context.DeleteQTCT(qtct.id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidQTCTResult qtct = con.GetidQTCT(id).FirstOrDefault();
            return View(qtct);
        }

        [ValidateInput(true)]
        public ActionResult Edit(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidQTCTResult qtct = con.GetidQTCT(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                int MaNV = int.Parse(Request.Form["MaNV"]);
                int MaPB = int.Parse(Request.Form["MaPB"]);
                DateTime TGBD = DateTime.Parse(Request.Form["TGBD"]);
                DateTime TGKT = DateTime.Parse(Request.Form["TGKT"]);
                
                con.EditQTCT(qtct.id, MaNV, MaPB,TGBD,TGKT);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(qtct);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From QUATRINHCONGTAC";
            DataTable dt = new DataTable();
            dt.TableName = "QUATRINHCONGTAC";
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
                Response.AddHeader("content-disposition", "attachment;filename= QuaTrinhCongTacReport.xlsx");

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