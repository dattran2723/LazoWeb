﻿using LazoWeb.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LazoWeb.Areas.Admin.Controllers
{
    public class CustomersController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Customers
        public ActionResult Index()
        {
            return View(db.Customers.OrderByDescending(x => x.RegisterDate).ToList());
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer cus = db.Customers.Find(customer.ID);
                    cus.Name = customer.Name;
                    cus.Company = customer.Company;
                    cus.NumberEmployee = customer.NumberEmployee;
                    cus.Address = customer.Address;
                    cus.Description = customer.Description;
                    cus.Status = customer.Status;
                    db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var customer = db.Customers.Find(id);
            customer.Status = !customer.Status;
            db.SaveChanges();
            var kq = customer.Status;
            return Json(new
            {
                status = kq
            });
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
