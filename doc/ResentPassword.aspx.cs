using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;

public partial class ResentPassword : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }

    protected void GetPasswordButton_Click(object sender, ImageClickEventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {
                int status = 0;
                if (EmailAddressTextBox.Text != "")
                {
                    Users.EmailAddress = EmailAddressTextBox.Text;
                    Users.ActivationToken = GenerateRandomString();
                    Users.LoginName = "";
                    string val = Users.ResendPassword("EMAIL");
                    string[] retVal = val.Split(';');
                    if (retVal.Length > 0)
                    {
                        status = Convert.ToInt32(retVal[0]);
                        Users.EmailAddress = Convert.ToString(retVal[1]);
                    }
                }
                if (UsernameTextBox.Text != "")
                {
                    string val = Users.ResendPassword("USER");
                    string[] retVal = val.Split(';');
                    if (retVal.Length > 0)
                    {
                        status = Convert.ToInt32(retVal[0]);
                        Users.EmailAddress = Convert.ToString(retVal[1]);
                    }
                }

                switch (status)
                {
                    case 1:     //Invalid Email Address
                        MessageLabel.Text = "Invalid Email Address. Sorry! We could not find email-address you specified !!!";
                        break;
                    case 11:    //Invalid Email Address or Activation Key Not Found
                        MessageLabel.Text = "Invalid Email Address. Sorry! We could not find email-address you specified !!!";
                        break;
                    case 12:    //Account not activated
                        MessageLabel.Text = "We found your email-address but it seems that your account is not activated yet. A mail has been sent to your email-address, please follow the instructions in your inbox !!!";
                        SendActivationEmail(Users.EmailAddress, Users.ActivationToken);
                        break;
                    case 13:    //Activation key has been expired
                        MessageLabel.Text = "We found your email-address but it seems that your account is not activated yet. A mail has been sent to your email-address, please follow the instructions in your inbox !!!";
                        SendActivationEmail(Users.EmailAddress, Users.ActivationToken);
                        break;
                    case 2:     //Invalid Username
                        MessageLabel.Text = "Invalid Username. Sorry! We could not find username you specified !!!";
                        break;
                    case 3:     //Login details found
                        MessageLabel.Text = "Hurray! Your login details has been sent to your email address. Please follow the instructions in your inbox!!!";
                        SendLoginDetails(Users.EmailAddress, Users.ActivationToken);
                        break;
                }
            }
            catch(Exception ex)
            {
            }
        //}
    }

    private void SendLoginDetails(string email, string token)
    {
        Email o = new Email();
        StringBuilder messageTemplate = new StringBuilder();
        string Template = HttpContext.Current.Server.MapPath("~\\EMailTemplate\\") + "ResetPassword.txt";
        using (StreamReader rwOpenTemplate = new StreamReader(Template))
        {
            while (!rwOpenTemplate.EndOfStream)
            {
                messageTemplate.Append(rwOpenTemplate.ReadToEnd());
            }
        }

        StringBuilder resetURL = new StringBuilder();
        resetURL.Append("<a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/PasswordReset.aspx");
        resetURL.Append("?eml=" + Encrypt(email, ConfigurationManager.AppSettings["ENCKI"].ToString()));
        resetURL.Append("&token=" + Encrypt(token, ConfigurationManager.AppSettings["ENCKI"].ToString()));
        resetURL.Append("'>......../");
        resetURL.Append("&token=" + Encrypt(token, ConfigurationManager.AppSettings["ENCKI"].ToString()));
        resetURL.Append("</a>");
        messageTemplate.Replace("<!-#REGISTRATIONLINK#->", resetURL.ToString());
        o.SendNewRegistrationMail("Lost password request from AMAD Support Center", email, messageTemplate.ToString());
        MessageLabel.Text = "An email has been sent to reset your password. Kindly follow the instructions in you mail-box.";
    }

    private void SendActivationEmail(string email, string token)
    {
        DataSet ds = Users.GetUserDetailsForActivation(email);
        Email o = new Email();
        StringBuilder messageTemplate = new StringBuilder();
        string Template = HttpContext.Current.Server.MapPath("~\\EMailTemplate\\") + "registration.txt";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                using (StreamReader rwOpenTemplate = new StreamReader(Template))
                {
                    while (!rwOpenTemplate.EndOfStream)
                    {
                        messageTemplate.Append(rwOpenTemplate.ReadToEnd());
                    }
                }

                StringBuilder resetURL = new StringBuilder();
                resetURL.Append("<a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/UserProfile.aspx");
                resetURL.Append("?eml=" + Encrypt(ds.Tables[0].Rows[0]["EmailAddress"].ToString(), ConfigurationManager.AppSettings["ENCKI"].ToString()));
                resetURL.Append("&mbl=" + Encrypt(ds.Tables[0].Rows[0]["MobileNumber"].ToString(), ConfigurationManager.AppSettings["ENCKI"].ToString()));
                resetURL.Append("&isp=" + Encrypt("No", ConfigurationManager.AppSettings["ENCKI"].ToString()));
                resetURL.Append("&fname=");
                resetURL.Append("&lname=");
                resetURL.Append("&token=" + Encrypt(token, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                resetURL.Append("'>......../");
                resetURL.Append("fname=");
                resetURL.Append("&lname=");
                resetURL.Append("&token=" + Encrypt(token, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                resetURL.Append("</a>");
                messageTemplate.Replace("<!-#REGISTRATIONLINK#->", resetURL.ToString());
                o.SendNewRegistrationMail("Thank you for registering with AMAD", ds.Tables[0].Rows[0]["EmailAddress"].ToString(), messageTemplate.ToString());
                MessageLabel.Text = "Thank you for choosing AMAD. Your profile is saved with us but is not activated. Kindly follow the instructions in you mail-box.";
            }
        }
        
        
        
    }

}
