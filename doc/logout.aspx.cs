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

public partial class logout : AMADBasePage
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
                Session.Clear();
                Session.Abandon();
                //HeaderMessageLabel.Text = "Your Account has been activated successfuly";
                //LabelText.Text = "Your Account has been activated successfuly";
                //Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/index.aspx", true);
            }
        }
    }
}
