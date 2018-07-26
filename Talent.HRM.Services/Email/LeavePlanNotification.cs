using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Talent.HRM.Services.Interfaces;
using TalentAcquisition.DataLayer;

namespace Talent.HRM.Services.Email
{
   public class LeavePlanNotification: IEmailMessaging
    {
        TalentContext db = new TalentContext();
        public LeavePlanNotification(string employeesmail)
        {
            Employeesmail = employeesmail;
            
        }

        public string Employeesmail { get; set; }
        
        public void SendEmail(string to, string from)
        {

        }
        public void SendEmailToApplicant()
        {
        //var EmpMails = db.Employees.Select(c => c.Email).ToList();

            try
            {
                MailMessage mailMessage = new MailMessage("info@talenthrm.net", this.Employeesmail);
                mailMessage.Subject = "Leave Plan";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "Hello, \n\n Dear Staff, Please be informed that you are expected to send your leave plan across to the HOD \n\nBest Regards.";
                //mailMessage.CC.Add("adgarba@erpschoolafrica.com");
                //mailMessage.Bcc.Add("info@codeware.com.ng");
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "mail.oohwantech.com";
                smtpClient.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential("lukman@oohwantech.com", "Me@digit01");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = NetworkCred;
                smtpClient.Port = 25;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //LblEmailStatus.Text = "Could not send the e-mail - error: " + ex.Message;
            }
        }
    }
}
