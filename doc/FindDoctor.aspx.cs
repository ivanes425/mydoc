using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.IO;

public partial class FindDoctor : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartment();
            BindCityAndArea();
            GetImageSlider();       
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

    void BindCityAndArea()
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
        
        HospitalCityList.DataSource = dvCities.ToTable();
        HospitalCityList.DataTextField = "City";
        HospitalCityList.DataValueField = "City";
        HospitalCityList.DataBind();
        HospitalCityList.Items.Insert(0, "Select");

        HospitalAreaList.DataSource = ds;
        HospitalAreaList.DataTextField = "LocationName";
        HospitalAreaList.DataValueField = "LocationId";
        HospitalAreaList.DataBind();
        HospitalAreaList.Items.Insert(0, "Select");

        HospitalList.Items.Insert(0, "Select");

        LabCityList.DataSource = dvCities.ToTable();
        LabCityList.DataTextField = "City";
        LabCityList.DataValueField = "City";
        LabCityList.DataBind();
        LabCityList.Items.Insert(0, "Select");

        LabAreaList.DataSource = ds;
        LabAreaList.DataTextField = "LocationName";
        LabAreaList.DataValueField = "LocationId";
        LabAreaList.DataBind();
        LabAreaList.Items.Insert(0, "Select");

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

    private void GetImageSlider()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~\\ImagesAndText.xml"));

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].TableName == "FindDoctor")
            {
                LiteralImageSlider.Text = ImageSlider(ds.Tables["FindDoctor"]);
            }
        }

        //ArrayList arr = new ArrayList();
        //arr.Add("images/onlineConsultation.jpg");
        //arr.Add("images/Health-Insurance.jpg");
        //arr.Add("images/samplecollection.jpg");
        //LiteralImageSlider.Text = ImageSlider(arr);
    }

    
}
