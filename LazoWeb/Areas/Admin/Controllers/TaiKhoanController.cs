using LazoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazoWeb.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        public ActionResult List()
        {
            var db = new ApplicationDbContext();
            var user = db.Users.ToList();
            return View(user);
        }
    }
}