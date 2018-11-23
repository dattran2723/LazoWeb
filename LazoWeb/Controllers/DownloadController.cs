using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazoWeb.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IOS()
        {
            return Redirect("https://itunes.apple.com/us/app/lazo-anh-khu%C3%AA/id1439308876?ls=1&mt=8");
        }

        public ActionResult Android()
        {
            return Redirect("https://play.google.com/store/apps/details?id=vn.com.iotlink.lazo");
        }
    }
}