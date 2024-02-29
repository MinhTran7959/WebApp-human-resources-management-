using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace QLNS_LTW.Models
{
    public class LoginModel
    {
        QLNSDataContext db = new QLNSDataContext();
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

    }
    

    
}