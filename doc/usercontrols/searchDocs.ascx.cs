using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class usercontrols_searchDocs : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDepartment();
        BindCity();
        BindArea();
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
        foreach (ListItem _listItem in this.DepartmentList.Items)
        {
            _listItem.Attributes.Add("title", _listItem.Text);
        }
    }

    void BindCity()
    {
        Doctors o = new Doctors();
        DataSet ds = o.GetCitiesAndAreas();
        DataView dvCities = new DataView(ds.Tables[0]);
        DataView dvAreas = new DataView(ds.Tables[0]);
        dvCities.RowFilter = " Distinct City";
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

    void BindArea()
    {
        //Doctors o = new Doctors();
        //AreaList.DataSource = o.GetCities();
        //AreaList.DataTextField = "LocationName";
        //AreaList.DataValueField = "LocationId";
        //AreaList.DataBind();
        //AreaList.Items.Insert(0, "Select");
    }

    protected void FindDoctorsButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {

        }
    }
}
