using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazoWeb.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if((Session["amdin"] == null && Session["login"] != null) || (Session["amdin"] != null && Session["login"] == null))
            //{
            //    filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
            //}

            if (Session["login"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}