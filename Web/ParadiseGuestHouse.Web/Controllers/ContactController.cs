namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Web.ViewModels.Contact;

    public class ContactController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("nqmazasq"));  // replace with valid value
                message.From = new MailAddress(model.Email);  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FirstName, model.LastName, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "nqmazasq",  // replace with valid value
                        Password = "nqmazasq",  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return this.RedirectToAction("Sent");
                }
            }

            return this.View(model);
        }

        public ActionResult Sent()
        {
            return this.Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
        }
    }
}
