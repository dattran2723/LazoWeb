using System;
using System.Collections.Generic;
using System.Configuration;
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
            string url = string.Empty;
            try
            {
                url = ConfigurationManager.AppSettings["LazoIOSDownloadLink"];
            }
            catch (Exception ex)
            {
                url = "https://itunes.apple.com/us/app/lazo-anh-khu%C3%AA/id1439308876";
            }

            return Redirect(url);
        }

        public ActionResult Android()
        {
            string url = string.Empty;
            try
            {
                url = ConfigurationManager.AppSettings["LazoAndroidDownloadLink"];
            }
            catch (Exception ex)
            {
                url = "https://play.google.com/store/apps/details?id=vn.com.iotlink.lazo";
            }

            return Redirect(url);
        }
    }
}