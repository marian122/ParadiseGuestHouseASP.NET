namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Common;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Web.ViewModels.Contact;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class ContactController : Controller
    {
    //    private readonly IRepository<ContactForm> contactsRepository;
    //    private readonly IEmailSender emailSender;

    //    public ContactController(IRepository<ContactForm> contactsRepository, IEmailSender emailSender)
    //    {
    //        this.contactsRepository = contactsRepository;
    //        this.emailSender = emailSender;
    //    }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            // TODO: Extract to IP provider (service)
            //var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

            //var contactFormEntry = new ContactForm
            //{
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    Email = model.Email,
            //    Title = model.Title,
            //    Content = model.Content,
            //    Ip = ip,
            //};

            //await this.contactsRepository.AddAsync(contactFormEntry);
            //await this.contactsRepository.SaveChangesAsync();

            //await this.emailSender.SendEmailAsync(model.Email, model.Title, model.Content);

            //await this.emailSender.SendEmailAsync(
            //    model.Email,
            //    model.FirstName,
            //    model.LastName,
            //    GlobalConstants.SystemEmail,
            //    model.Title,
            //    model.Content);

            var client = new SendGridClient("");
            var name = model.FirstName + " " + model.LastName;
            var from = new EmailAddress(model.Email, name);
            var subject = model.Title;
            var to = new EmailAddress("paradiseguesthouse@abv.bg", "ParadiseGuestHouse");
            var plainTextContent = model.Content;
            var htmlContent = $"<strong>{model.Content}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            await client.SendEmailAsync(msg);

            return this.Redirect("/");
        }
    }
}
