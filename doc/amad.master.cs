using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class amad : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/LoginRegister.aspx";
        FindDoctorHyperLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/FindDoctor.aspx";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ForgotPassLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/ResentPassword.aspx";
            RegisterLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/LoginRegister.aspx";
            LogOutHyperLink.NavigateUrl = ConfigurationManager.AppSettings["ROOTURL"].ToString() + "/Logout.aspx";
            BindDepartment();
            BindCity();
            if (Request.Url.AbsolutePath == ConfigurationManager.AppSettings["APPHOME_ABSOLUTEPATH"].ToString())
                bannerdiv.Style["display"] = "block";
            else
                bannerdiv.Style["display"] = "none";
            if (Session["UserData"] != null)
            {
                if (((DataTable)(Session["UserData"])).Rows[0]["LastLoggedIn"].ToString() == "")
                {
                    LoginNameLabel.Text = "Welcome " + ((DataTable)(Session["UserData"])).Rows[0]["FirstName"].ToString();
                    LastLoginTimeLabel.Text = "This is your first login<br/>";
                }
                else
                {
                    LoginNameLabel.Text = "Welcome back " + ((DataTable)(Session["UserData"])).Rows[0]["FirstName"].ToString();
                    LastLoginTimeLabel.Text = "You last logged on:<br/>" + ((DataTable)(Session["UserData"])).Rows[0]["LastLoggedIn"].ToString();
                }
                postLoginDiv.Style["display"] = "block";
                RegisterHyperLink.Visible = false;
                SignInHyperlink.Visible = false;
                LogOutHyperLink.Visible = true;
            }
            else
            {
                LoginNameLabel.Text = "";
                LastLoginTimeLabel.Text = "";
                postLoginDiv.Style["display"] = "none";
                RegisterHyperLink.Visible = true;
                SignInHyperlink.Visible = true;
                LogOutHyperLink.Visible = false;
            }
        }
        else
        {
            if (Session["UserData"] != null)
            {
                if (((DataTable)(Session["UserData"])).Rows[0]["LastLoggedIn"].ToString() == "")
                {
                    LoginNameLabel.Text = "Welcome " + ((DataTable)(Session["UserData"])).Rows[0]["FirstName"].ToString();
                    LastLoginTimeLabel.Text = "This is your first login<br/>";
                }
                else
                {
                    LoginNameLabel.Text = "Welcome back " + ((DataTable)(Session["UserData"])).Rows[0]["FirstName"].ToString();
                    LastLoginTimeLabel.Text = "You last logged on:<br/>" + ((DataTable)(Session["UserData"])).Rows[0]["LastLoggedIn"].ToString();
                }
                postLoginDiv.Style["display"] = "block";
                RegisterHyperLink.Visible = false;
                SignInHyperlink.Visible = false;
                LogOutHyperLink.Visible = true;
            }
            else
            {
                LoginNameLabel.Text = "";
                LastLoginTimeLabel.Text = "";
                postLoginDiv.Style["display"] = "none";
                RegisterHyperLink.Visible = true;
                SignInHyperlink.Visible = true;
                LogOutHyperLink.Visible = false;
            }
        }
    }
    
    protected void FindDoctorsButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            HttpCookie aCookie = new HttpCookie(ConstantKeys.DoctorSearchInfo);
            aCookie.Values[ConstantKeys.SearchDepartment] = DepartmentList.SelectedItem.Text;
            aCookie.Values[ConstantKeys.SearchCity] = CityList.SelectedItem.Text;
            aCookie.Values[ConstantKeys.SearchArea] = AreaList.SelectedItem.Text;
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);

            Response.Redirect(ConfigurationManager.AppSettings["ROOTURL"] + "/DoctorsList.aspx");
        }
    }

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
                    if (Convert.ToString(ds.Tables[0].Rows[0]["LastLoggedIn"]) == "")
                    {
                        LastLoginTimeLabel.Text = "This is your first login<br/>";
                        LoginNameLabel.Text = "Welcome " + ds.Tables[0].Rows[0]["FirstName"].ToString();
                    }
                    else
                    {
                        LastLoginTimeLabel.Text = "You last logged-in on:<br/>" + ds.Tables[0].Rows[0]["LastLoggedIn"].ToString();
                        LoginNameLabel.Text = "Welcome back " + ds.Tables[0].Rows[0]["FirstName"].ToString();
                    }
                    postLoginDiv.Style["display"] = "block";
                    Session["UserData"] = ds.Tables[0];
                    RegisterHyperLink.Visible = false;
                    SignInHyperlink.Visible = false;
                    LogOutHyperLink.Visible = true;
                }
                else
                {
                    LoginNameLabel.Text = "";
                    LastLoginTimeLabel.Text = "";
                    postLoginDiv.Style["display"] = "none";
                    RegisterHyperLink.Visible = true;
                    SignInHyperlink.Visible = true;
                    LogOutHyperLink.Visible = false;
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
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "login", "openLoginModal();", true);

        }
    }

    void BindDepartment()
    {
        Doctors o = new Doctors();
        DataSet ds = o.getDepartment();
        DepartmentList.DataSource = ds;
        DepartmentList.DataTextField = "ShortName";
        DepartmentList.DataValueField = "Id";
        DepartmentList.DataBind();
        DepartmentList.Items.Insert(0, "Select");
    }

    void BindCity()
    {
        Doctors o = new Doctors();
        DataSet ds = o.GetCitiesAndAreas();
        DataView dvCities = new DataView(ds.Tables[0]);
        DataView dvAreas = new DataView(ds.Tables[0]);
        //dvCities.RowFilter = " Distinct City";
        CityList.DataSource = dvCities.ToTable();
        CityList.DataTextField = "City";
        CityList.DataValueField = "City";
        CityList.DataBind();
        CityList.Items.Insert(0, "Select");

        AreaList.DataSource = ds;
        AreaList.DataTextField = "LocationName";
        AreaList.DataValueField = "LocationId";
        AreaList.DataBind();
        AreaList.Items.Insert(0, "Select");
    }

}
