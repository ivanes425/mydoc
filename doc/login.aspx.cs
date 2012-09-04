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

public partial class Login : AMADBasePage
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
                    //LabelText.Text = "Your Account has been activated successfuly";
                }
                if (Convert.ToString(Request.QueryString["msg"]) == "passchanged")
                {
                    //HeaderMessageLabel.Text = "Your password has been changed successfully";
                    //LabelText.Text = "Your password has been changed successfully";
                }
                if (Convert.ToString(Request.QueryString["msg"]) == "profileupdate")
                {
                    //HeaderMessageLabel.Text = "Your profile has been updated successfully";
                    //LabelText.Text = "Your profile has been updated successfully";
                }
            }
            else
            {
                //HeaderMessageLabel.Text = "Your Account has been activated successfuly";
                //LabelText.Text = "Your Account has been activated successfuly";
                //Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/index.aspx", true);
            }
            if (Request.QueryString["eml"] != null)
            {
                UserNameTextBox.Text = Request.QueryString["eml"];
                PasswordTextBox.Text = "";
            }
            ForgotPassLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/ResentPassword.aspx";
            RegisterLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/LoginRegister.aspx";
        }
    }

    protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                AMADBasePage bp = new AMADBasePage();
                DataSet ds = Users.ValidateLogin(UserNameTextBox.Text, PasswordTextBox.Text);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["LoginName"] = ds.Tables[0].Rows[0]["FirstName"].ToString(); 
                        Session["LastLoginTime"] = ds.Tables[0].Rows[0]["LastLoggedIn"].ToString();
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
                        Session["LoginName"] = null;
                        Session["LastLoginTime"] = null;
                        Session["UserData"] = null;
                        RegisterLabel.Text = "Username and/or password is invalid.";
                        //Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/Login.aspx");
                    }
                }
                else
                {
                    Session["LoginName"] = null;
                    Session["LastLoginTime"] = null;
                    Session["UserData"] = null;
                    RegisterLabel.Text = "Username and/or password is invalid.";
                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}
