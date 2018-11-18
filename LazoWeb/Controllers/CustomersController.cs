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
        public async Task<ActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool isEmail = CheckExistingEmail(customer.Email);
                bool isPhone = CheckExistingPhone(customer.Phone);
                if (isEmail && isPhone)
                {
                    customer.RegisterDate = DateTime.Now;
                    db.Customers.Add(customer);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        await SendMailForCustomer(customer);
                        Session["signup"] = "success";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công!");
                        return View(customer);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Số điện thoại hoặc Email đã tồn tại");
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

        public bool CheckExistingPhone(string phone)
        {
            var result = db.Customers.Where(s => s.Phone == phone).Count();

            if (result > 0)
            {

                return false;
            }
            else
            {
                return true;
            }
        }

        public Task SendMailForCustomer(Customer customer)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("dattran2723@gmail.com", "ltigyvnwvdxhpwmo");
            //var notification = "Cảm ơn bạn đã đăng ký sử dụng dịch vụ của Lazo. Chúng tôi sẽ liên hệ với bạn ngay khi có thể";
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
