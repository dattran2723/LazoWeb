﻿using LazoWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LazoWeb.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin/User
        public ActionResult GetAllUser()
        {
            return View(db.Users.OrderByDescending(x => x.CreatedDate).ToList());
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser model = db.Users.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(model.Id);
                user.LastName = model.LastName;
                user.FirstName = model.FirstName;
                //user.EmailConfirmed = model.EmailConfirmed;
                UserManager.Update(user);
                ApplicationUser userlogin = (ApplicationUser)Session["login"];
                if (userlogin.Email.Equals(user.Email))
                {
                    ApplicationUser query = db.Users.Where(m => m.Email == model.Email).FirstOrDefault();
                    Session["login"] = query;
                }
                ViewData["Edit"] = true;
            }
            return View(model);
        }
        public int DeleteConfirmedUser(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            var result = db.SaveChanges();
            return result;
        }
        public ActionResult delete(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            var result = db.SaveChanges();
            return RedirectToAction("Getalluser", "User", new { area = "admin" });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}