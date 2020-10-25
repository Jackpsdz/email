using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using email.Models;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace email.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(email.Models.Sendemail model, HttpPostedFileBase fileUploader)
        {
            MailMessage mm = new MailMessage("jackpsdz96@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            if (fileUploader !=null)
            {
                string fileName = Path.GetFileName(fileUploader.FileName);

                mm.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("jackpsdz96@gmail.com", "luzhening0214");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent succsessfully!";

            return View();
        }
    }
}