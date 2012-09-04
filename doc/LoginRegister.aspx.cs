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

public partial class LoginRegister : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserData"] != null)
                Response.Redirect("~/index.aspx");
        }
    }

    protected void RegisterNewUser_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Email o = new Email();
            Users.IsPatient = Convert.ToBoolean(IsPatient.SelectedValue);
            Users.FirstName = FirstNameTextBox.Text;
            Users.LastName = LastNameTextBox.Text;
            Users.EmailAddress = EmailAddressTexBox.Text;
            Users.MobileNumber = MobileNumberTextBox.Text;
            Users.ActivationToken = GenerateRandomString();
            if (Users.checkUserAvailability() == "-1" || Users.checkUserAvailability() == "0")
            {
                string val = Users.RegisterUser();
                if (val == "" || val == "0")
                    RegisterLabel.Text = "Sorry! we could not register your records. Kindly try after some time. Sorry for the Incovenience";
                else
                {
                    StringBuilder messageTemplate = new StringBuilder();
                    string Template = HttpContext.Current.Server.MapPath("~\\EMailTemplate\\") + "registration.txt";
                    using (StreamReader rwOpenTemplate = new StreamReader(Template))
                    {
                        while (!rwOpenTemplate.EndOfStream)
                        {
                            messageTemplate.Append(rwOpenTemplate.ReadToEnd());
                        }
                    }

                    StringBuilder resetURL = new StringBuilder();
                    resetURL.Append("<a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/UserProfile.aspx");
                    resetURL.Append("?eml=" + Encrypt(EmailAddressTexBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&mbl=" + Encrypt(MobileNumberTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&isp=" + Encrypt(IsPatient.SelectedItem.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&fname=" + Encrypt(FirstNameTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&lname=" + Encrypt(LastNameTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&token=" + Encrypt(Users.ActivationToken, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("'>......../");
                    resetURL.Append("fname=" + Encrypt(FirstNameTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&lname=" + Encrypt(LastNameTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("&token=" + Encrypt(Users.ActivationToken, ConfigurationManager.AppSettings["ENCKI"].ToString()));
                    resetURL.Append("</a>");
                    messageTemplate.Replace("<!-#REGISTRATIONLINK#->", resetURL.ToString());
                    o.SendNewRegistrationMail("Thank you for registering with AMAD", EmailAddressTexBox.Text, messageTemplate.ToString());
                    RegisterLabel.Text = "Thank you for choosing AMAD. Your profile is saved with us but is not activated. Kindly follow the instructions in you mail-box.";
                }

            }

        }
        catch(Exception ex)
        {
        }
    }

    protected void CheckAvailabilityButton_Click(object sender, EventArgs e)
    {
        try
        {
            Users.EmailAddress = EmailAddressTexBox.Text;
            string ret = Users.checkUserAvailability();
            if (ret == "-1" || ret == "0")
            {
                RegisterNewUser.Enabled = true;
                EmailAddressTexBox.CssClass = "emailAvailable";
                emailAvailCheckImg.Visible = true;
                emailAvailCheckImg.ImageUrl = ConfigurationManager.AppSettings["ROOTURL"] + "/images/valid.jpg";
            }
            else
            {
                RegisterNewUser.Enabled = false;
                EmailAddressTexBox.CssClass = "emailNotAvailable";
                emailAvailCheckImg.Visible = true;
                emailAvailCheckImg.ImageUrl = ConfigurationManager.AppSettings["ROOTURL"] + "/images/invalid.jpg";
            }
        }
        catch(Exception ex)
        {
        }
    }

    protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                AMADBasePage bp = new AMADBasePage();
                DataSet ds = Users.ValidateLogin(UsernameTextBox.Text, PasswordTextBox.Text);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["UserData"] = ds.Tables[0];
                        if (ds.Tables[0].Rows[0]["UserType"].ToString() == "DOCTOR")
                        {
                            Doctors doc = new Doctors();
                            DataSet dsDoc = doc.GetDoctorsDetailsByEmail(ds.Tables[0].Rows[0]["EmailAddress"].ToString());
                            if (dsDoc == null)
                                Response.Redirect("UnAuthorizedAccess.aspx");
                            else
                            {
                                Session["DoctorData"] = dsDoc.Tables[0];
                                Response.Redirect("ManageSchedule.aspx");
                            }
                        }
                        else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "USER")
                            Response.Redirect("BookAppointment.aspx");
                    }
                    else
                    {
                        Session["UserData"] = null;
                        Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/Login.aspx");
                    }
                }
            }
            catch { }

        }
    }
}
