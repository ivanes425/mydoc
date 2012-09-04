using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;

public partial class UserProfile : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["eml"] != null || Request.QueryString["mbl"] != null)
            {
                string tokenId = Decrypt(Request.QueryString["token"], ConfigurationManager.AppSettings["ENCKI"].ToString());
                EmailAddressTexBox.Text = Decrypt(Request.QueryString["eml"], ConfigurationManager.AppSettings["ENCKI"].ToString());
                MobileNumberTextBox.Text = Decrypt(Request.QueryString["mbl"], ConfigurationManager.AppSettings["ENCKI"].ToString());
                FirstNameTextBox.Text = Decrypt(Request.QueryString["fname"], ConfigurationManager.AppSettings["ENCKI"].ToString());
                LastNameTextBox.Text = Decrypt(Request.QueryString["lname"], ConfigurationManager.AppSettings["ENCKI"].ToString());
                if(Decrypt(Request.QueryString["isp"], ConfigurationManager.AppSettings["ENCKI"].ToString()) == "No")
                    IsPatient.SelectedValue = "false";
                else
                    IsPatient.SelectedValue = "true";
            }
            else
            {
                //Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/index.aspx", true);
            }
        }
    }

    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Users.IsPatient = Convert.ToBoolean(IsPatient.SelectedValue);
                Users.FirstName = FirstNameTextBox.Text;
                Users.LastName = LastNameTextBox.Text;
                Users.EmailAddress = EmailAddressTexBox.Text;
                Users.MobileNumber = MobileNumberTextBox.Text;
                Users.ActivationToken = Request.QueryString["token"];
                Users.Address = AddressTextBox.Text;
                Users.City = CityTextBox.Text;
                Users.EmergenyNumber = EmergencyNumberTextBox.Text;
                Users.Gender = GenderList.SelectedItem.Value;
                Users.HomeOfficeNumber = PhoneNumberTextBox.Text;
                Users.LoginName = LoginNameTextBox.Text;
                Users.RelationShipWithPatient = RelationshipTextBox.Text;

                if (Users.checkLoginNameAvailability() == "0")
                {
                    int result = Users.ActivateUserAccount(BuildListOfValues());

                    switch (result)
                    {
                        case 0:
                            RegisterLabel.Text = "Invalid Email Address or Activation Key Not Found !!!";
                            break;
                        case 1:
                            sendConfirmationEmail();
                            //RegisterLabel.Text = "Your account has been activated successfully. You can now <a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/login.aspx?eml=" + EmailAddressTexBox.Text + "'>login</a> and access your personalized health care solution. Click <a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/findDoctor.aspx'>here</a> to book your appointment with best doctors available around you !!!";
                            Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/ProfileUpdate.aspx?msg=activated?eml=" + EmailAddressTexBox.Text);
                            break;
                        case 2:
                            RegisterLabel.Text = "This Account has been already activated. Kindly <a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/login.aspx?eml=" + EmailAddressTexBox.Text + "'>login</a> to access your personalized health care solution!!!";
                            break;
                        case 3:
                            RegisterLabel.Text = "Your Activation key has been expired. Kindly click <a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/loginregister.aspx?eml=" + EmailAddressTexBox.Text + "'>here</a> to re-generate your activation key !!!";
                            break;
                    }
                }
                else
                    RegisterLabel.Text = "This Login Name is already taken. Kindly choose another name";

            }
            catch(Exception ex)
            {
            }
        }
    }

    protected void CheckAvailabilityButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (LoginNameTextBox.Text != "")
            {
                if (ValidateLoginName())
                {
                    Users.LoginName = LoginNameTextBox.Text;
                    string ret = Users.checkLoginNameAvailability();
                    if (ret == "-1" || ret == "0")
                    {
                        SubmitButton.Enabled = true;
                        LoginNameTextBox.CssClass = "emailAvailable";
                    }
                    else
                    {
                        SubmitButton.Enabled = false;
                        LoginNameTextBox.CssClass = "emailNotAvailable";
                    }
                }
            }
            else
                RegisterLabel.Text = "Please enter the login name first to check the availability.";
        }
        catch (Exception ex)
        {
        }
    }

    private bool ValidateLoginName()
    {
        bool isValid = true;
        if (LoginNameTextBox.Text.Length >= 8 && LoginNameTextBox.Text.Length <= 20)
        {
            string invalidChars = "!,%,*,(,),+,',:,;,.,<,>,?,/,|,},{,],[,~,,";
            string[] invalid = invalidChars.Split(',');
            for (int i = 0; i <= invalid.Length - 1; i++)
            {
                for (int k = 0; k <= LoginNameTextBox.Text.Length - 1; k++)
                {
                    if(LoginNameTextBox.Text.Contains(invalid[i]))
                        isValid = false;
                }
            }
        }
        else
            isValid = false;

        return isValid;
    }

    private void sendConfirmationEmail()
    {
        Email o = new Email();
        StringBuilder messageTemplate = new StringBuilder();
        string Template = HttpContext.Current.Server.MapPath("~\\EMailTemplate\\") + "NewRegistration.txt";
        using (StreamReader rwOpenTemplate = new StreamReader(Template))
        {
            while (!rwOpenTemplate.EndOfStream)
            {
                messageTemplate.Append(rwOpenTemplate.ReadToEnd());
            }
        }

        StringBuilder resetURL = new StringBuilder();
        StringBuilder mailDeatils = new StringBuilder();

        mailDeatils.Append("<b>Congratulations,</b> <b>" + FirstNameTextBox.Text + "</b><br/><br/>");
        mailDeatils.Append("<h3>Your account has been activated successfully. You can now enjoy your </h3><br/><li>personalized health care services</li><li>book an instant appointments with your favourite doctors</li><li>get your health related queries answered by our expert panel of doctors<li><li>and lots more...</li>");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to book an appointment with the Doctor");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to ask questions about your health and our expert panel of doctors will respond");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to know doctors nearest to you");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to read various health tips");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to know '<b>Dadi ke nuske</b>'");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to edit your profile");
        mailDeatils.Append("<br/><a href='#'>Click here</a> to change your password");
        mailDeatils.Append("<br/><br/><br/>If you have any concerns, please contact us at <a href='mailto:info@appointmeadoc.com'>info@appointmeadoc.com</a>");
        messageTemplate.Replace("<!-#MESSAGE1#->", mailDeatils.ToString());
        o.SendNewRegistrationMail("Your account has been activated with AMAD", EmailAddressTexBox.Text, messageTemplate.ToString());
    }

    
    public override Dictionary<string, string> BuildListOfValues()
    {
        Dictionary<string, string> listValues = new Dictionary<string, string>();
        listValues.Add("FirstName", FirstNameTextBox.Text);
        listValues.Add("LastName", LastNameTextBox.Text);
        listValues.Add("Gender", GenderList.SelectedItem.Text);
        listValues.Add("Address", AddressTextBox.Text);
        listValues.Add("IPAddress", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString());
        listValues.Add("Relationship", RelationshipTextBox.Text);
        listValues.Add("City", CityTextBox.Text);
        listValues.Add("LoginName", LoginNameTextBox.Text);
        listValues.Add("HomeOfficeNumber", PhoneNumberTextBox.Text);
        listValues.Add("Password", Encrypt(PasswordTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
        listValues.Add("State", "");
        listValues.Add("EmergencyContact", EmergencyNumberTextBox.Text);
        listValues.Add("IsPatient", IsPatient.SelectedItem.Value);
        listValues.Add("EmailAddress", EmailAddressTexBox.Text);
        return listValues;
    }
}
