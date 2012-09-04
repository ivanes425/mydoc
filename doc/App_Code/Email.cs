using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
	public Email()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void SendNewRegistrationMail(string subject, string toemail, string body)
    {
        try
        {
            SmtpClient smtpClinet = new SmtpClient();
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.Body = body;
            msg.To.Add(new MailAddress(toemail));

            string strEmails = ConfigurationManager.AppSettings["BCCEMAIL"].ToString();
            String[] arrEmails = strEmails.Split(';');
            for (int j = 0; j < arrEmails.Length; j++)
            {
                if (arrEmails[j] != "")
                {
                    msg.Bcc.Add(new MailAddress(arrEmails[j]));
                }
            }

            msg.From = new MailAddress(ConfigurationManager.AppSettings["FROMEMAIL"]);
            msg.Subject = subject;

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential("appointmeadoc@gmail.com", "oowdytech123");
            
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = credential;
            //client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            client.Send(msg);
        }
        catch(Exception ex)
        {
        }
    }
}
