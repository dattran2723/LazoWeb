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
            if(!Request.IsAuthenticated)
            {
                filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}