using CaptchaMvc.HtmlHelpers;
using LazoWeb.Models;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LazoWeb.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


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
        public async Task<ActionResult> Register(Customer customer)
        {
            if (this.IsCaptchaValid("Mã xác nhận không đúng!") && ModelState.IsValid)
            {
                customer.RegisterDate = DateTime.Now;
                db.Customers.Add(customer);
                var res = db.SaveChanges();
                await SendMailForCustomer(customer);
                ViewData["register"] = true;
                return View();

            }

            return View(customer);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult CheckExistingEmail(string Email)
        {
            var result = db.Customers.Where(s => s.Email == Email).Count();
            if (result > 0)
                return Json(false);
            return Json(true);
        }

        [HttpPost]
        public ActionResult CheckExistingPhone(string Phone)
        {
            var result = db.Customers.Where(s => s.Phone == Phone).Count();
            if (result > 0)
                return Json(false);
            return Json(true);
        }

        public Task SendMailForCustomer(Customer customer)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("dattran2723@gmail.com", "ltigyvnwvdxhpwmo");

            //Nội dung mail
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Views/Customers/MailContent.cshtml"));
            content = content.Replace("{{Name}}", customer.Name);
            content = content.Replace("{{Company}}", customer.Company);
            content = content.Replace("{{NumberEmployee}}", customer.NumberEmployee.ToString());
            content = content.Replace("{{Phone}}", customer.Phone);
            content = content.Replace("{{Email}}", customer.Email);

            var fromEmail = new MailAddress("dattran2723@gmail.com", "Lazo");
            var toEmail = new MailAddress(customer.Email);
            var mail = new MailMessage(fromEmail, toEmail)
            {
                Subject = "Thông báo",
                Body = content,
                IsBodyHtml = true,
                BodyEncoding = UTF8Encoding.UTF8

            };

            smtp.Send(mail);

            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

    }
}
