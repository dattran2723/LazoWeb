using LazoWeb.Models;
using System.Linq;
using System.Web.Mvc;

namespace LazoWeb.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/User
        public ActionResult GetAllUser()
        {
            return View(db.Users.ToList());
        }
    }
}