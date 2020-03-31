namespace ParadiseGuestHouse.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using ParadiseGuestHouse.Web.InputModels.Contact;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class ContactController : Controller
    {
        private readonly IConfiguration configuration;

        public ContactController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

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

            var apiKey = this.configuration.GetValue<string>("SendGrid:ApiKey");

            var client = new SendGridClient(apiKey);
            var name = model.FirstName + " " + model.LastName;
            var from = new EmailAddress(model.Email, name);
            var subject = model.Title;
            var to = new EmailAddress("paradiseguesthouse@abv.bg", "ParadiseGuestHouse");
            var plainTextContent = model.Content;
            var htmlContent = $"<p>{model.Content}</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            await client.SendEmailAsync(msg);

            return this.Redirect("/");
        }
    }
}
