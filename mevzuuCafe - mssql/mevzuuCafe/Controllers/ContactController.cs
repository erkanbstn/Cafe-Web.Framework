using mevzuuCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
namespace mevzuuCafe.Controllers
{
    public class ContactController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add("info.mevzuucafe@gmail.com");
            mailim.From = new MailAddress("info.mevzuucafe@gmail.com");
            mailim.Subject = "Site ziyaretçisinden mesaj var :   " + model.Baslik;
            mailim.Body = "Sayın yetkili, " + model.AdSoyad+ "isimli kullanıcıdan gelen mesaj aşağıda.<br> " + model.Icerik + "<br><br>kullanıcının maili: "+ model.GonderenMail;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("info.mevzuucafe@gmail.com", "06MevzuCafe06");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mailim);
                TempData["Mesage"] = "Mesajınız iletilmiştir.";
            }
            catch (Exception ex)
            {
                TempData["Mesage"] = "Mesajınız iletilemedi.." + ex.Message;
            }

            return View();
        }
    }
}