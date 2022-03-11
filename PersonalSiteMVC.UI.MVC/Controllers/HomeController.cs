using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSiteMVC.UI.MVC.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ContactAjax(ContactViewModel cvm)
        {

            string body = $"{cvm.Name} has sent you the following message:<br/>" +
                $"{cvm.Message} from: {cvm.Email}.";
            //Message Object
            MailMessage mm = new MailMessage(
            //FROM address - email must be on host - creds stored in Web.config
            ConfigurationManager.AppSettings["EmailUser"].ToString(),
            //TO - email doesn't have to be on host - creds stored in Web.config
            ConfigurationManager.AppSettings["EmailTo"].ToString(),
            //email subject
            cvm.Subject,
            body);

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(),
            ConfigurationManager.AppSettings["EmailPass"].ToString());

            try
            {
                //send email
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"We're sorry your request could not be completed at this time" +
                    $"Please try again later.\nError Message: {ex.StackTrace}";

            }
            return Json(cvm);

        }

    }
}