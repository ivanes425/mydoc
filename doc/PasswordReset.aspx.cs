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

public partial class PasswordReset : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["eml"] != null)
            {
                if (Users.VerifyTokenPasswordReset(Decrypt(Request.QueryString["token"], ConfigurationManager.AppSettings["ENCKI"]), Decrypt(Request.QueryString["eml"], ConfigurationManager.AppSettings["ENCKI"])) != "1")
                {
                    Response.Redirect("~/SessionExpired.aspx");
                }
                else
                {
                    EmailAddressTextBox.Text = Decrypt(Request.QueryString["eml"], ConfigurationManager.AppSettings["ENCKI"]);
                }
            }
        }
    }

    protected void ResetPasswordButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                int status = 0;
                status = Users.UpdatePassword(Encrypt(PasswordTextBox.Text, ConfigurationManager.AppSettings["ENCKI"]), EmailAddressTextBox.Text);
                if (status == 1)
                    MessageLabel.Text = "Your password has been reset successfully. Click <a href='" + ConfigurationManager.AppSettings["ROOTURL"] + "/Login.aspx?eml=" + EmailAddressTextBox.Text +"'>here</a> to login";
                else
                    MessageLabel.Text = "Your password could not be reset. Kindly try again or contact <a href='mailto:support@appointmeadoc.com?subject=Could not reset the password'>support desk</a>";
            }
            catch(Exception ex)
            {
            }
        }
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

}
