using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class amad_inner : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
       RegisterHyperLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/LoginRegister.aspx";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ForgotPassLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/ResentPassword.aspx";
            RegisterLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/LoginRegister.aspx";
            //BindDepartment();
            //BindArea();
            //BindCity();
            if (Session["UserData"] != null)
            {
                LoginNameLabel.Text = ((DataTable)(Session["UserData"])).Rows[0]["FirstName"].ToString();
                LastLoginTimeLabel.Text = ((DataTable)(Session["UserData"])).Rows[0]["LastLoggedIn"].ToString();
                postLoginDiv.Style["display"] = "block";
                RegisterHyperLink.Visible = false;
                SignInHyperlink.Visible = false;
                LogOutHyperlink.Visible = true;
            }
            else
            {
                LoginNameLabel.Text = "";
                LastLoginTimeLabel.Text = "";
                postLoginDiv.Style["display"] = "none";
                RegisterHyperLink.Visible = true;
                SignInHyperlink.Visible = true;
                LogOutHyperlink.Visible = false;
            }
        }
    }

    /*
    void BindDepartment()
    {
        Doctors o = new Doctors();
        DepartmentList.DataSource = o.getDepartment();
        DepartmentList.DataTextField = "ShortName";
        DepartmentList.DataValueField = "Id";
        DepartmentList.DataBind();
        DepartmentList.Items.Insert(0, "Select");
    }

    void BindCity()
    {
        Doctors o = new Doctors();
        CityList.DataSource = o.getDepartment();
        CityList.DataTextField = "ShortName";
        CityList.DataValueField = "Id";
        CityList.DataBind();
        CityList.Items.Insert(0, "Select");
    }

    void BindArea()
    {
        Doctors o = new Doctors();
        AreaList.DataSource = o.getDepartment();
        AreaList.DataTextField = "ShortName";
        AreaList.DataValueField = "Id";
        AreaList.DataBind();
        AreaList.Items.Insert(0, "Select");
    }
    */

    protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            AMADBasePage bp = new AMADBasePage();
            DataSet ds = Users.ValidateLogin(UserNameTextBox.Text, PasswordTextBox.Text);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LoginNameLabel.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    LastLoginTimeLabel.Text = ds.Tables[0].Rows[0]["LastLoggedIn"].ToString();
                    postLoginDiv.Style["display"] = "block";
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
                    else
                        Response.Redirect("BookAppointment.aspx");
                }
                else
                {
                    Session["UserData"] = null;
                    LoginNameLabel.Text = "";
                    LastLoginTimeLabel.Text = "";
                    postLoginDiv.Style["display"] = "none";
                    Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/Login.aspx");
                }
            }
            else
            {
                LoginNameLabel.Text = "";
                LastLoginTimeLabel.Text = "";
                postLoginDiv.Style["display"] = "none";
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "enable2", "openLoginModal();", true);
        }
    }
}
