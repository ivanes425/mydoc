using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;

public partial class ProfileUpdate : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["msg"] != null)
            {
                if (Convert.ToString(Request.QueryString["msg"]) == "activated")
                {
                    //HeaderMessageLabel.Text = "Your Account has been activated successfuly";
                    LabelText.Text = "Your Account has been activated successfuly. You can now <a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/login.aspx?eml=" + Request.QueryString["eml"] + "'>login</a> and access your personalized health care solution. Click <a href='" + ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/findDoctor.aspx'>here</a> to book your appointment with best doctors available around you !!!";
                }
                if (Convert.ToString(Request.QueryString["msg"]) == "passchanged")
                {
                    //HeaderMessageLabel.Text = "Your password has been changed successfully";
                    LabelText.Text = "Your password has been changed successfully";
                }
                if (Convert.ToString(Request.QueryString["msg"]) == "profileupdate")
                {
                    //HeaderMessageLabel.Text = "Your profile has been updated successfully";
                    LabelText.Text = "Your profile has been updated successfully";
                }
            }
            else
            {
                //HeaderMessageLabel.Text = "Your Account has been activated successfuly";
                LabelText.Text = "Your Account has been activated successfuly";
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
            
        }
        catch (Exception ex)
        {
        }
    }

    private void sendConfirmationEmail()
    {
        
    }

    
    public override Dictionary<string, string> BuildListOfValues()
    {
        Dictionary<string, string> listValues = new Dictionary<string, string>();
        //listValues.Add("FirstName", FirstNameTextBox.Text);
        //listValues.Add("LastName", LastNameTextBox.Text);
        //listValues.Add("Gender", GenderList.SelectedItem.Text);
        //listValues.Add("Address", AddressTextBox.Text);
        //listValues.Add("IPAddress", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString());
        //listValues.Add("Relationship", RelationshipTextBox.Text);
        //listValues.Add("City", CityTextBox.Text);
        //listValues.Add("LoginName", LoginNameTextBox.Text);
        //listValues.Add("HomeOfficeNumber", PhoneNumberTextBox.Text);
        //listValues.Add("Password", Encrypt(PasswordTextBox.Text, ConfigurationManager.AppSettings["ENCKI"].ToString()));
        //listValues.Add("State", "");
        //listValues.Add("EmergencyContact", EmergencyNumberTextBox.Text);
        //listValues.Add("IsPatient", IsPatient.SelectedItem.Value);
        //listValues.Add("EmailAddress", EmailAddressTexBox.Text);
        return listValues;
    }
}
