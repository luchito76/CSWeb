using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mail;
using System.Web.UI;
using System.Web;


using System.Text;

namespace CuotaSystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError().GetBaseException();

            if (exc.GetBaseException() is HttpRequestValidationException)
            {
                System.Diagnostics.Trace.WriteLine(exc.ToString());
                Server.ClearError();
            }

            // Notifica el error por mail al administrador del sistema (Luchito Fantasía)
            string from = "luisparadawagner@gmail.com";
            string to = "luisparadawagner@gmail.com";
            string subject = exc.Message.ToString();
            string message = exc.GetBaseException().ToString();
            string password = "zapalino76";
            string smtpUrl = "smtp.gmail.com";
            int port = 587;
            string username = "luisparadawagner@gmail.com";
            bool ssl = false;

            Sendemail(from, to, subject, message, password, smtpUrl, port, username, ssl);

            //Limpia el error en servidor
            Server.ClearError();
            Server.Transfer("PaginaError.aspx?error=" + exc.Message);
        }

        public static void mandarMail(string subject, string message)
        {
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();
            objEmail.From = new System.Net.Mail.MailAddress("luchito76@aridosparada.com");
            objEmail.ReplyToList.Add("luisparadawagner@gmail.com"); //= new System.Net.Mail.MailAddressCollection(); new System.Net.Mail.MailAddress("Cuenta@MiDominio.com");
            //objEmail.ReplyTo = new System.Net.Mail.MailAddress("Cuenta@MiDominio.com");
            //Destinatario
            objEmail.To.Add("luisparadawagner@gmail.com");

            objEmail.Priority = System.Net.Mail.MailPriority.Normal;
            objEmail.Subject = subject;
            objEmail.Body = message;
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();
            objSmtp.Host = "localhost";
            objSmtp.Send(objEmail);
        }

        public static void Sendemail(string from, string to, string subject, string message, string password, string smtpUrl, int port, string userName, bool ssl)
        {
            try
            {
                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(from, to, subject, message);

                MyMailMessage.IsBodyHtml = false;

                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(userName, password);

                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                mailClient.EnableSsl = true;

                mailClient.UseDefaultCredentials = false;

                mailClient.Credentials = mailAuthentication;

                mailClient.Send(MyMailMessage);
            }
            catch
            {
                throw;
            }
        }
    }
}