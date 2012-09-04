using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;
using Google.GData.Client;
using Google.GData.Calendar;
using Google.GData.Extensions;
using Google.GData;
using System.Net;
using System.Data;

public partial class DoctorsList : AMADBasePage
{
    string sGoogleUserName = "appointmeadoc@gmail.com";
    string sGooglePassword = "oowdytech123";
    public DataSet dsSchedule
    {
        get { return (DataSet)(ViewState["dsSchedule"]); }
        set { ViewState["dsSchedule"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Cookies[ConstantKeys.DoctorSearchInfo] != null)
            {
                string dept = Server.HtmlEncode(Request.Cookies[ConstantKeys.DoctorSearchInfo][ConstantKeys.SearchDepartment]);
                string city = Server.HtmlEncode(Request.Cookies[ConstantKeys.DoctorSearchInfo][ConstantKeys.SearchCity]);
                string area = Server.HtmlEncode(Request.Cookies[ConstantKeys.DoctorSearchInfo][ConstantKeys.SearchArea]);
                DepartmentLabel.Text = "<b style='color:#D8322C'>" + dept + "</b>" + " in <b style='color:#D8322C'>" + area + "</b>, <b style='color:#D8322C'>" + city + "</b>";
                Doctors dc = new Doctors();
                dsSchedule = dc.GetDoctorsListForAppointment(dept, city, area);
                //GAuthenticate();
                dataListDoctors.DataSource = dsSchedule.Tables[0];
                dataListDoctors.DataBind();
            }
        }
    }

    protected void rptDoctorsAppointments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("gvAvailableSlots") != null)
        {
            //GridView gvControls = ((GridView)e.Item.FindControl("gvAvailableSlots"));
            ////gvControls.CssClass = "newTextStyle";
            //DataView dv = new DataView(dsSchedule.Tables[1]);
            //dv.RowFilter = "DoctorId = " + ((System.Data.DataRowView)(e.Item.DataItem)).Row["Id"].ToString();
            //DataTable dt = new DataTable();
            //string col1 = Convert.ToDateTime(dv.ToTable().Rows[0]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");
            //string col2 = Convert.ToDateTime(dv.ToTable().Rows[2]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");
            //string col3 = Convert.ToDateTime(dv.ToTable().Rows[4]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");
            //string col4 = Convert.ToDateTime(dv.ToTable().Rows[6]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");
            //string col5 = Convert.ToDateTime(dv.ToTable().Rows[8]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");
            //string col6 = Convert.ToDateTime(dv.ToTable().Rows[10]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");
            //string col7 = Convert.ToDateTime(dv.ToTable().Rows[12]["ScheduleDate"].ToString()).ToString("dd-MMM-yyyy");

            //dt.Columns.Add(new DataColumn(col1));
            //dt.Columns.Add(new DataColumn(col2));
            //dt.Columns.Add(new DataColumn(col3));
            //dt.Columns.Add(new DataColumn(col4));
            //dt.Columns.Add(new DataColumn(col5));
            //dt.Columns.Add(new DataColumn(col6));
            //dt.Columns.Add(new DataColumn(col7));
            ////dt = dv.ToTable();
            //DataRow dr1 = dt.NewRow();
            //dr1[col1] = "";
            //dr1[col1] = "";
            //dr1[col1] = "";
            //dr1[col1] = "";
            //dr1[col1] = "";
            //dr1[col1] = "";
            //dr1[col1] = "";
            //dt.Rows.Add(dr1);
            //DataRow dr2 = dt.NewRow();
            //dr2["D"] = "";
            //dr2["D1"] = "";
            //dr2["D2"] = "";
            //dr2["D3"] = "";
            //dr2["D4"] = "";
            //dr2["D5"] = "";
            //dr2["D6"] = "";
            //dt.Rows.Add(dr2);

            //dt.Rows[0]["D"] = dv.ToTable().Rows[0]["D"].ToString();
            //dt.Rows[1]["D"] = dv.ToTable().Rows[1]["D"].ToString();
            
            //dt.Rows[0]["D1"] = dv.ToTable().Rows[2]["D1"].ToString();
            //dt.Rows[1]["D1"] = dv.ToTable().Rows[3]["D1"].ToString();
            
            //dt.Rows[0]["D2"] = dv.ToTable().Rows[4]["D2"].ToString();
            //dt.Rows[1]["D2"] = dv.ToTable().Rows[5]["D2"].ToString();
            
            //dt.Rows[0]["D3"] = dv.ToTable().Rows[6]["D3"].ToString();
            //dt.Rows[1]["D3"] = dv.ToTable().Rows[7]["D3"].ToString();
            
            //dt.Rows[0]["D4"] = dv.ToTable().Rows[8]["D4"].ToString();
            //dt.Rows[1]["D4"] = dv.ToTable().Rows[9]["D4"].ToString();
            
            //dt.Rows[0]["D5"] = dv.ToTable().Rows[10]["D5"].ToString();
            //dt.Rows[1]["D5"] = dv.ToTable().Rows[11]["D5"].ToString();
            
            //dt.Rows[0]["D6"] = dv.ToTable().Rows[12]["D6"].ToString();
            //dt.Rows[1]["D6"] = dv.ToTable().Rows[13]["D6"].ToString();

            //gvControls.DataSource = dt;
            //gvControls.DataBind();
        }
    }


    private CalendarService GAuthenticate()
    {
        Uri oCalendarUri = new Uri("http://www.google.com/calendar/feeds/llio4kg13jso3rr3m0l3jthc2c@group.calendar.google.com/private/full");
        //Uri oCalendarUri = new Uri("http://www.google.com/calendar/feeds/pankaj.sevlani@gmail.com/private/full");
        //Initialize Calendar Service
        CalendarService oCalendarService = new CalendarService("CalendarSampleApp");
        oCalendarService.setUserCredentials(sGoogleUserName, sGooglePassword);

        //Use Proxy 
        GDataRequestFactory oRequestFactory = (GDataRequestFactory)oCalendarService.RequestFactory;
        WebProxy oWebProxy = new WebProxy(WebRequest.DefaultWebProxy.GetProxy(oCalendarUri));
        oWebProxy.Credentials = CredentialCache.DefaultCredentials;
        oWebProxy.UseDefaultCredentials = true;
        oRequestFactory.Proxy = oWebProxy;

        return oCalendarService;
    }

}
