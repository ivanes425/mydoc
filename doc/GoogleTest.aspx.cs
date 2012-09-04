using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Client;
using Google.GData.Calendar;
using Google.GData.Extensions;
using Google.GData;
using System.Net;
using System.Data;

public partial class GoogleTest : System.Web.UI.Page
{
    string sGoogleUserName = "appointmeadoc@gmail.com";
    string sGooglePassword = "oowdytech123";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //CreateNewEvent();
        //GetEvents();
        GetDoctorsSchedule();
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

    private void GetDoctorsSchedule()
    {
        CalendarService oCalendarService = GAuthenticate();
        
        //Search for Event
        EventQuery oEventQuery = new EventQuery();
        oEventQuery.Uri = new Uri("https://www.google.com/calendar/feeds/llio4kg13jso3rr3m0l3jthc2c@group.calendar.google.com/private/full");
        //oEventQuery.Query = "Query String";
        oEventQuery.ExtraParameters = "orderby=starttime&sortorder=ascending";
        oEventQuery.StartTime = DateTime.Now;
        oEventQuery.EndTime = DateTime.Now.AddDays(50);
        //oEventQuery.SingleEvents = true;

        Google.GData.Calendar.EventFeed oEventFeed = oCalendarService.Query(oEventQuery);
        string dt = "";
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("EventTitle"));
        table.Columns.Add(new DataColumn("EventSummary"));
        table.Columns.Add(new DataColumn("EventStartDate"));
        table.Columns.Add(new DataColumn("EventEndDate"));
        table.Columns.Add(new DataColumn("EventStatus"));
        table.Columns.Add(new DataColumn("EventId"));
        table.Columns.Add(new DataColumn("EventLocation"));
        table.Columns.Add(new DataColumn("EventUId"));

        foreach (var entry in oEventFeed.Entries)
        {
            Google.GData.Calendar.EventEntry eventEntry = entry as Google.GData.Calendar.EventEntry;
            if (eventEntry != null)
            {
                if (eventEntry.Times.Count != 0)
                {
                    DataRow dr = table.NewRow();
                    dr["EventUId"] = eventEntry.Uid.Value;
                    dr["EventId"] = eventEntry.EventId.ToString();
                    dr["EventTitle"] = eventEntry.Title.Text;
                    dr["EventSummary"] = eventEntry.Summary.Text;
                    dr["EventStartDate"] = eventEntry.Times[0].StartTime.ToString("dd/MM/yyyy");
                    dr["EventEndDate"] = eventEntry.Times[0].EndTime.ToString("dd/MM/yyyy");
                    dr["EventStatus"] = eventEntry.Status.Value.ToString();
                    dr["EventLocation"] = Convert.ToString(eventEntry.Locations[0].ValueString);
                    table.Rows.Add(dr);
                    //dt = dt + eventEntry.Title.Text + "<br/>";
                }
            }
        }
        //eventsLabel.Text = dt;
        gvCal.DataSource = table;
        gvCal.DataBind();
    }

    private void CreateNewEvent()
    {
        //Set Event Entry 
        Google.GData.Calendar.EventEntry oEventEntry = new Google.GData.Calendar.EventEntry();
        oEventEntry.Title.Text = "Test Calendar Entry From .Net for testing";
        oEventEntry.Content.Content = "Hurrah!!! I posted my second Google calendar event through .Net";

        //Set Event Location 
        Where oEventLocation = new Where();
        oEventLocation.ValueString = "Mumbai";
        oEventEntry.Locations.Add(oEventLocation);

        //Set Event Time
        When oEventTime = new When(new DateTime(2012, 8, 05, 9, 0, 0), new DateTime(2012, 8, 05, 9, 0, 0).AddHours(1));
        oEventEntry.Times.Add(oEventTime);

        //Set Additional Properties
        ExtendedProperty oExtendedProperty = new ExtendedProperty();
        oExtendedProperty.Name = "SynchronizationID";
        oExtendedProperty.Value = Guid.NewGuid().ToString();
        oEventEntry.ExtensionElements.Add(oExtendedProperty);

        CalendarService oCalendarService = GAuthenticate();
        Uri oCalendarUri = new Uri("http://www.google.com/calendar/feeds/pankaj.sevlani@gmail.com/private/full");

        //Prevents This Error
        //{"The remote server returned an error: (417) Expectation failed."}
        System.Net.ServicePointManager.Expect100Continue = false;

        //Save Event
        oCalendarService.Insert(oCalendarUri, oEventEntry);
    }

    private void GetEvents()
    {
        CalendarService oCalendarService = GAuthenticate();
        //Uri oCalendarUri = new Uri("https://www.google.com/calendar/feeds/pankaj.sevlani@gmail.com/private/full");

        //Search for Event
        EventQuery oEventQuery = new EventQuery();
        oEventQuery.Uri = new Uri("https://www.google.com/calendar/feeds/pankaj.sevlani@gmail.com/private/full");
        //oEventQuery.Query = "Query String";
        oEventQuery.ExtraParameters = "orderby=starttime&sortorder=ascending";
        oEventQuery.StartTime = DateTime.Now;
        oEventQuery.EndTime = DateTime.Now.AddDays(50);
        //oEventQuery.SingleEvents = true;
        
        Google.GData.Calendar.EventFeed oEventFeed = oCalendarService.Query(oEventQuery);
        string dt = "";
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("EventTitle"));
        table.Columns.Add(new DataColumn("EventSummary"));
        table.Columns.Add(new DataColumn("EventStartDate"));
        table.Columns.Add(new DataColumn("EventEndDate"));
        table.Columns.Add(new DataColumn("EventStatus"));
        table.Columns.Add(new DataColumn("EventId"));
        table.Columns.Add(new DataColumn("EventLocation"));
        table.Columns.Add(new DataColumn("EventUId"));

        foreach (var entry in oEventFeed.Entries)
        {
           Google.GData.Calendar.EventEntry eventEntry = entry as Google.GData.Calendar.EventEntry;
           if (eventEntry != null)
           {
               if (eventEntry.Times.Count != 0)
               {
                   DataRow dr = table.NewRow();
                   dr["EventUId"] = eventEntry.Uid.Value;
                   dr["EventId"] = eventEntry.EventId.ToString();
                   dr["EventTitle"] = eventEntry.Title.Text;
                   dr["EventSummary"] = eventEntry.Summary.Text;
                   dr["EventStartDate"] = eventEntry.Times[0].StartTime.ToString("dd/MM/yyyy");
                   dr["EventEndDate"] = eventEntry.Times[0].EndTime.ToString("dd/MM/yyyy");
                   dr["EventStatus"] = eventEntry.Status.Value.ToString();
                   dr["EventLocation"] = Convert.ToString(eventEntry.Locations[0].ValueString);
                   table.Rows.Add(dr);
                   //dt = dt + eventEntry.Title.Text + "<br/>";
               }
           }
        }
        //eventsLabel.Text = dt;
        gvCal.DataSource = table;
        gvCal.DataBind();
    }

    private void UpdateEvent()
    {
        CalendarService oCalendarService = GAuthenticate();

        //Search for Event
        EventQuery oEventQuery = new EventQuery();
        oEventQuery.Uri = new Uri("https://www.google.com/calendar/feeds/pankaj.sevlani@gmail.com/private/full");
        oEventQuery.ExtraParameters = "extq=[SynchronizationID:{Your GUID Here}]";

        Google.GData.Calendar.EventFeed oEventFeed = oCalendarService.Query(oEventQuery);

        //Update Related Events
        foreach (Google.GData.Calendar.EventEntry oEventEntry in oEventFeed.Entries)
        {
            //Update Event
            oEventEntry.Title.Text = "Updated Entry";
            oCalendarService.Update(oEventEntry);
            break;
        }
    }

    private void DeleteEvent()
    {
        CalendarService oCalendarService = GAuthenticate();

        //Search for Event
        EventQuery oEventQuery = new EventQuery();
        oEventQuery.Uri = new Uri("https://www.google.com/calendar/feeds/pankaj.sevlani@gmail.com/private/full");
        oEventQuery.ExtraParameters = "extq=[SynchronizationID:{Your GUID Here}]";

        Google.GData.Calendar.EventFeed oEventFeed = oCalendarService.Query(oEventQuery);

        //Delete Related Events
        foreach (Google.GData.Calendar.EventEntry oEventEntry in oEventFeed.Entries)
        {
            oEventEntry.Delete();
            break;
        }
    }
}
