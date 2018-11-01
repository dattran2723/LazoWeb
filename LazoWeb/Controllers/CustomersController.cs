﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using LazoWeb.Models;

namespace LazoWeb.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        //public ActionResult Index()
        //{
        //    return View(db.Customers.ToList());
        //}

        // GET: Customers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // GET: Customers/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register([Bind(Include = "ID,Name,Company,NumberEmployee,Address,Email,Status")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool result = CheckExistingEmail(customer.Email);
                if (result)
                {
                    db.Customers.Add(customer);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential("dattran2723@gmail.com", "khatvong");
                        var notification = "Bạn đã đăng ký dịch vụ Lazo";
                        smtp.Send("dattran2723@gmail.com", customer.Email, "Thông báo", notification);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công!");
                        return View(customer);
                    }
                }
                else
                {
                    ModelState.AddModelError("","Email đã tồn tại");
                    return View(customer);
                }
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,Company,NumberEmployee,Address,Email,Status")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(customer);
        //}

        // GET: Customers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    db.Customers.Remove(customer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool CheckExistingEmail(string email)
        {
            var result = db.Customers.Where(s => s.Email == email).Count();

            if (result > 0)
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
