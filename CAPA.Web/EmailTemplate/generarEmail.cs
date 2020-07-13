using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace CAPA.Web.EmailTemplate
{
    public class generarEmail
    { 
        utilitario ut; 
        public generarEmail()
        {
            ut = new utilitario();
        }

        public void crearPlantillaEmail(string subjectText, string bodyText, string atfrom, string credencial, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = atfrom; 
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            enviarEmail(mail, atfrom, credencial);
        }

        public void enviarEmail(MailMessage mail, string origen, string credencial)
        {
            utilitario ut = new utilitario();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //smtp.mail.yahoo.com, smtp - mail.outlook.com,  
            smtp.Port = 25; //465; //587
            smtp.Credentials = new NetworkCredential(origen, credencial);
            smtp.EnableSsl = true;
            // client.UseDefaultCredentials = false;
            // client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            { 
                Debug.WriteLine("No se a podido enviar mail: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                smtp.Dispose();
            }
        }
          
    }
}