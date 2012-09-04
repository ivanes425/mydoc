using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Doctors
/// </summary>
public class Doctors
{
	public Doctors()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region Properties & Variables
    private int _docId;
    private string _scheduleType;
    private DateTime _scheduleFromDate;
    private DateTime _scheduleToDate;
    private string _docCode;
    private string _availFrom;
    private string _availTo;

    public int DoctorId
    {
        get { return _docId; }
        set { _docId = value; }
    }

    public string ScheduleType
    {
        get { return _scheduleType; }
        set { _scheduleType = value; }
    }
    public DateTime ScheduleFromDate
    {
        get { return _scheduleFromDate; }
        set { _scheduleFromDate = value; }
    }
    public DateTime ScheduleToDate
    {
        get { return _scheduleToDate; }
        set { _scheduleToDate = value; }
    }
    public string DoctorCode
    {
        get { return _docCode; }
        set { _docCode = value; }
    }
    public string AvailableFrom
    {
        get { return _availFrom; }
        set { _availFrom = value; }
    }
    public string AvailableTo
    {
        get { return _availTo; }
        set { _availTo = value; }
    }

    #endregion

    public DataSet getDepartment()
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        return db.ExecuteDataSet("fb_amad_GetDepartments");
    }

    public DataSet GetCitiesAndAreas()
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        return db.ExecuteDataSetNonQuery("SELECT DISTINCT LocationId,LocationName,City FROM FB_LOCATION WHERE Active = 'true'");
    }

    public int CreateDoctorsSchedule()
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("DoctorId", this.DoctorId);
        SqlParameter p2 = new SqlParameter("SchFromDate", this.ScheduleFromDate);
        SqlParameter p3 = new SqlParameter("SchToDate", this.ScheduleToDate);
        SqlParameter p4 = new SqlParameter("AvailableFrom", this.AvailableFrom);
        SqlParameter p5 = new SqlParameter("AvailableTo", this.AvailableTo);
        SqlParameter p6 = new SqlParameter("DoctorCode", this.DoctorCode);
        SqlParameter p7 = new SqlParameter("ScheduleType", this.ScheduleType);
        SqlParameter p8 = new SqlParameter("StatusId", 0);
        SqlParameter p9 = new SqlParameter("StatusDesc", "");
        p8.Direction = ParameterDirection.Output;
        p9.Direction = ParameterDirection.Output;
        object o = db.ExecuteScalar("fb_amad_CreateDoctorsSchedule", p1,p2,p3,p4,p5,p6,p7,p8,p9);
        int stsId = Convert.ToInt32(Convert.ToString(p8.Value));
        string stsDesc = Convert.ToString(p9.Value);

        return stsId;
    }

    public DataSet GetDoctorScheduleById()
    {
        DataSet ds = new DataSet();
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("DoctorId", this.DoctorId);
        SqlParameter p2 = new SqlParameter("StatusId", 0);
        SqlParameter p3 = new SqlParameter("StatusDesc", "");
        p2.Direction = ParameterDirection.Output;
        p3.Direction = ParameterDirection.Output;
        ds = db.ExecuteDataSet("fb_amad_GetDoctorsScheduleById", p1, p2, p3);
        int stsId = Convert.ToInt32(Convert.ToString(p2.Value));
        string stsDesc = Convert.ToString(p3.Value);
        return ds;
    }

    public DataSet GetDoctorsDetailsByEmail(string email)
    {
        DataSet ds = new DataSet();
        AMADBasePage obj = new AMADBasePage();
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("EmailAddress", email);
        SqlParameter p2 = new SqlParameter("RecordStatus", 0);
        p2.Direction = ParameterDirection.Output;
        ds = db.ExecuteDataSet("fb_amad_GetDoctorsDetailsByEmail", p1, p2);
        if (Convert.ToInt32(p2.Value) > 0)
            return ds;
        else
            return null;
    }

    public DataSet GetDoctorsListForAppointment(string dept, string city, string area)
    {
        DataSet ds = new DataSet();
        AMADBasePage obj = new AMADBasePage();
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("Department", dept);
        SqlParameter p2 = new SqlParameter("City", city);
        SqlParameter p3 = new SqlParameter("Area", area);
        SqlParameter p4 = new SqlParameter("StatusDesc", 0);
        SqlParameter p5 = new SqlParameter("AccountStatus", "");
        p4.Direction = ParameterDirection.Output;
        p5.Direction = ParameterDirection.Output;
        ds = db.ExecuteDataSet("fb_amad_GetDoctorsForAppointments", p1, p2, p3, p4, p5);
        if (Convert.ToInt32(p4.Value) > 0)
            return ds;
        else
            return null;
    }
}
