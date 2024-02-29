using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QLNS_LTW.Models;

namespace QLNS_LTW.Controllers
{
    
    public class Proc_TaiKhoanController : Controller
    {
        // GET: Proc_TaiKhoan
        
        QLNSDataContext context = new QLNSDataContext();

        [Authorize(Roles = "admin")]
        public ActionResult Index(string searchString)
        {
            List<ToanBoDanhSachTaiKhoanResult> dsTK = context.ToanBoDanhSachTaiKhoan().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsTK = context.ToanBoDanhSachTaiKhoan().Where(x => x.TaiKhoan.Contains(searchString)).ToList();
            }
            return View(dsTK);
        }
        
        [ValidateInput(true)]
        public ActionResult Create()
        {
            TempData["AllMaNV"] = context.ToanBoDanhSachNhanVien().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(TAIKHOAN tk)
        {
            var ct = new QLNSDataContext();
            
            ct.AddTaiKhoan(tk.MaNV, tk.TaiKhoan, tk.MatKhau, tk.LaQuanTri);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TAIKHOAN tk = context.TAIKHOANs.FirstOrDefault(x => x.id == id);
            if (tk != null)
            {
                context.DeleteTaiKhoan(tk.id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            QLNSDataContext con = new QLNSDataContext();
            GetidTaiKhoanResult khd = con.GetidTaiKhoan(id).FirstOrDefault();
            return View(khd);
        }



        [ValidateInput(true)]
        public ActionResult Edit(int id )
        {
            QLNSDataContext con = new QLNSDataContext();
            TempData["AllMaNV"] = context.GetidTaiKhoan(id).ToList();
            GetidTaiKhoanResult tk = con.GetidTaiKhoan(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                int MaNV = int.Parse(Request.Form["MaNV"]);
                string TaiKhoan = Request.Form["TaiKhoan"];
                string MatKhau  = Request.Form["MatKhau"];
                string LaQuanTri = Request.Form["LaQuanTri"];
               
                con.EditTaiKhoan(tk.id,MaNV, TaiKhoan, MatKhau, LaQuanTri);
                con.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(tk);
        }

        [ValidateInput(true)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel tk)
        {
            bool userExist = context.TAIKHOANs.Any(x => x.TaiKhoan == tk.TaiKhoan && x.MatKhau == tk.MatKhau);
            TAIKHOAN u = context.TAIKHOANs.FirstOrDefault(x => x.TaiKhoan == tk.TaiKhoan && x.MatKhau == tk.MatKhau);
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.TaiKhoan, true);
                return RedirectToAction("Index","Proc_NhanVien");
            }
            ModelState.AddModelError("","Tài khoản hoặc Mật khẩu sai!!!");
                
            return View();
        }

        
        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select * From TaiKhoan";
            DataTable dt = new DataTable();
            dt.TableName = "TaiKhoan";
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
                Response.AddHeader("content-disposition", "attachment;filename= TaiKhoanReport.xlsx");

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