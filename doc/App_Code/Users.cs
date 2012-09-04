using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Data.Sql;

/// <summary>
/// Summary description for Users
/// </summary>
public static class Users 
{
    #region Properties & Variables
    
    static string userId;
    public static string UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    static string firstName;
    public static string FirstName
    {
        get
        {
            return (firstName != null) ? firstName : "";
        }
        set { firstName = value; }
    }

    static string lastName;
    public static string LastName
    {
        get
        {
            return (lastName != null) ? lastName : "";
        }
        set { lastName = value; }
    }

    static string emailAddress;
    public static string EmailAddress
    {
        get { return (emailAddress != null) ? emailAddress : ""; }
        set { emailAddress = value; }
    }

    static string mobile;
    public static string MobileNumber
    {
        get { return (mobile != null) ? mobile : ""; }
        set { mobile = value; }
    }

    static string usertype;
    public static string UserType
    {
        get { return (usertype != null) ? usertype : ""; }
        set { usertype = value; }
    }
    
    static bool ispatient;
    public static bool IsPatient
    {
        get { return (ispatient != null) ? ispatient : false; }
        set { ispatient = value; }
    }

    static string activationtoken;
    public static string ActivationToken
    {
        get { return (activationtoken != null) ? activationtoken : ""; }
        set { activationtoken = value; }
    }

    static string pass;
    public static string UserPassword
    {
        get { return (pass != null) ? pass : ""; }
        set { pass = value; }
    }

    static int activStatus;
    public static int ActivationStatus
    {
        get { return (activStatus != null) ? activStatus : 0; }
        set { activStatus = value; }
    }

    static string activStatusDesc;
    public static string ActivationStatusDesc
    {
        get { return (activStatusDesc != null) ? activStatusDesc : ""; }
        set { activStatusDesc = value; }
    }

    static string docId;
    public static string DoctorId
    {
        get { return (docId != null) ? docId : ""; }
        set { docId = value; }
    }

    static string loginname;
    public static string LoginName
    {
        get { return (loginname != null) ? loginname : ""; }
        set { loginname = value; }
    }
    static string gender;
    public static string Gender
    {
        get { return (gender != null) ? gender : ""; }
        set { gender = value; }
    }
    static string city;
    public static string City
    {
        get { return (city != null) ? city : ""; }
        set { city = value; }
    }
    static string relwithPatient;
    public static string RelationShipWithPatient
    {
        get { return (relwithPatient != null) ? relwithPatient : ""; }
        set { relwithPatient = value; }
    }
    static string address;
    public static string Address
    {
        get { return (address != null) ? address : ""; }
        set { address = value; }
    }
    static string phone;
    public static string HomeOfficeNumber
    {
        get { return (phone != null) ? phone : ""; }
        set { phone = value; }
    }
    static string emergency;
    public static string EmergenyNumber
    {
        get { return (emergency != null) ? emergency : ""; }
        set { emergency = value; }
    }

    #endregion

    public static DataSet ValidateLogin(string username, string password)
    {
        int retval = 0;
        DataSet ds = new DataSet();
        if (username.Contains("@") && username.Contains("."))
        {
            AMADBasePage obj = new AMADBasePage();
            Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
            SqlParameter p1 = new SqlParameter("LoginName", username);
            SqlParameter p2 = new SqlParameter("Password", obj.Encrypt(password, ConfigurationManager.AppSettings["ENCKI"].ToString()));
            SqlParameter p3 = new SqlParameter("ApplicationName", "AMAD");
            SqlParameter p4 = new SqlParameter("UserNameType", "EMAIL");
            SqlParameter p5 = new SqlParameter("AccountStatus", 0);
            SqlParameter p6 = new SqlParameter("LoginType", "");
            p5.Direction = ParameterDirection.Output;
            p6.Direction = ParameterDirection.Output;
            ds = db.ExecuteDataSet("fb_ValidateLogin", p1, p2, p3, p4, p5, p6);
            UserType = Convert.ToString(p6.Value);
            retval = Convert.ToInt32(Convert.ToString(p5.Value));
        }
        else
        {
            AMADBasePage obj = new AMADBasePage();
            Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
            SqlParameter p1 = new SqlParameter("LoginName", username);
            SqlParameter p2 = new SqlParameter("Password", obj.Encrypt(password, ConfigurationManager.AppSettings["ENCKI"].ToString()));
            SqlParameter p3 = new SqlParameter("ApplicationName", "AMAD");
            SqlParameter p4 = new SqlParameter("UserNameType", "USERNAME");
            SqlParameter p5 = new SqlParameter("AccountStatus", "0");
            SqlParameter p6 = new SqlParameter("LoginType", "");
            p5.Direction = ParameterDirection.Output;
            p6.Direction = ParameterDirection.Output;
            ds = db.ExecuteDataSet("fb_ValidateLogin", p1, p2, p3, p4, p5, p6);
            UserType = Convert.ToString(p6.Value);
            retval = Convert.ToInt32(Convert.ToString(p5.Value));
        }
        return ds;
    }

    public static DataSet GetUserDetailsForActivation(string email)
    {
        DataSet ds = new DataSet();
        AMADBasePage obj = new AMADBasePage();
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("EmailAddress", email);
        ds = db.ExecuteDataSet("fb_amad_GetUserDetailsForActivation", p1);
        
        return ds;
    }

    public static string RegisterUser()
    {
        AMADBasePage obj = new AMADBasePage();
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("FirstName", FirstName);
        SqlParameter p2 = new SqlParameter("LastName", LastName);
        SqlParameter p3 = new SqlParameter("EmailAddress", EmailAddress);
        SqlParameter p4 = new SqlParameter("MobileNumber", MobileNumber);
        SqlParameter p5 = new SqlParameter("Token", ActivationToken);
        SqlParameter p6 = new SqlParameter("Password", obj.Encrypt(obj.GeneratePassword(), ConfigurationManager.AppSettings["ENCKI"].ToString()));
        SqlParameter p7 = new SqlParameter("IsPatient", IsPatient);
        SqlParameter p8 = new SqlParameter("Key", ConfigurationManager.AppSettings["ENCKI"].ToString());
        object o = db.ExecuteScalar("fb_amad_RegisterUser", p1, p2, p3, p4, p5, p6, p7, p8);
        return string.Format(o != null ? Convert.ToString(o) : "0");
    }

    public static string checkUserAvailability()
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        object o = db.ExecuteScalarNon("SELECT 1 from FB_ONLINEUSER WHERE EmailAddress = '" + EmailAddress + "'");
        return string.Format(o != null ? Convert.ToString(o) : "0");
    }

    public static string ResendPassword(string searchBy)
    {
        string retval = string.Empty;
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("Token", ActivationToken);
        SqlParameter p2 = new SqlParameter("EmailAddress", EmailAddress);
        SqlParameter p3 = new SqlParameter("UserName", LoginName);
        SqlParameter p4 = new SqlParameter("SearchBy", searchBy);
        SqlParameter p5 = new SqlParameter("AccountStatus", "0");
        SqlParameter p6 = new SqlParameter("StatusDesc", "");
        p2.Direction = ParameterDirection.InputOutput;
        p5.Direction = ParameterDirection.Output;
        p6.Direction = ParameterDirection.Output;
        object o = db.ExecuteScalar("fb_amad_ResendPassword", p1,p2,p3,p4,p5,p6);
        //return string.Format(o != null ? Convert.ToString(o) : "0");

        retval = Convert.ToString(p5.Value) + ";" + Convert.ToString(p2.Value);
        return retval;
    }

    public static string checkLoginNameAvailability()
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        object o = db.ExecuteScalarNon("SELECT 1 from FB_AMAD_USERMASTER WHERE LoginName = '" + LoginName + "'");
        return string.Format(o != null ? Convert.ToString(o) : "0");
    }

    //public static string validateLogin()
    //{
    //    Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
    //    SqlParameter p1 = new SqlParameter("LoginName", LoginName);
    //    SqlParameter p2 = new SqlParameter("Password", UserPassword);
    //    SqlParameter p3 = new SqlParameter("ApplicationName", "AMAD");
    //    SqlParameter p4 = new SqlParameter("UserNameType", UserType);
    //    SqlParameter p5 = new SqlParameter("AccountStatus", "");
    //    p5.Direction = ParameterDirection.Output;
    //    object o = db.ExecuteScalarNon("fb_amad_validateUserActivation", p1, p2, p3, p4, p5);

    //    ActivationStatusDesc = Convert.ToString(p5.Value);
    //    return Convert.ToString(p5.Value);
    //}

    public static void validateUserActivation(string token, string email)
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("Token", token);
        SqlParameter p2 = new SqlParameter("EmailAddress", email);
        SqlParameter p3 = new SqlParameter("AccountStatus", 0);
        SqlParameter p4 = new SqlParameter("StatusDesc", "");
        SqlParameter p5 = new SqlParameter("UserId", "");
        p3.Direction = ParameterDirection.Output;
        p4.Direction = ParameterDirection.Output;
        p5.Direction = ParameterDirection.Output;
        object o = db.ExecuteScalarNon("fb_amad_validateUserActivation", p1, p2, p3, p4, p5);

        ActivationStatus = Convert.ToInt32(p3.Value.ToString());
        ActivationStatusDesc = p4.Value.ToString();
        UserId = p5.Value.ToString();
    }

    public static int ActivateUserAccount(Dictionary<string, string> listValues)
    {
        ActivationStatus = 0;
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("UserValues", BuildXML(listValues));
        SqlParameter p2 = new SqlParameter("AccountStatus", 0);
        SqlParameter p3 = new SqlParameter("StatusDesc", "");
        
        p2.Direction = ParameterDirection.Output;
        p3.Direction = ParameterDirection.Output;

        object o = db.ExecuteScalarNon("fb_amad_AccountActivation", p1, p2, p3);

        if (Convert.ToString(p2.Value) != "")
            ActivationStatus = Convert.ToInt32(Convert.ToString(p2.Value));
        ActivationStatusDesc = Convert.ToString(p3.Value);
        return ActivationStatus;
    }

    public static string VerifyTokenPasswordReset(string token, string email)
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        object o = db.ExecuteScalarNon("SELECT 1 from FB_AMAD_USERMASTER WHERE ActivationToken = '" + token + "' and EmailAddress = '" + email + "' and TokenExpiryDate >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
        return string.Format(o != null ? Convert.ToString(o) : "0");
    }

    public static int UpdatePassword(string pass, string email)
    {
        Database db = new Database(ConnectionManager.GetDatabaseConnectionString());
        SqlParameter p1 = new SqlParameter("Password", pass);
        SqlParameter p2 = new SqlParameter("EmailAddress", email);
        SqlParameter p3 = new SqlParameter("AccountStatus", 0);
        SqlParameter p4 = new SqlParameter("StatusDesc", "");

        p3.Direction = ParameterDirection.Output;
        p4.Direction = ParameterDirection.Output;

        object o = db.ExecuteScalarNon("fb_amad_UpdatePassword", p1, p2, p3, p4);

        return Convert.ToInt32(Convert.ToString(p3.Value));
    }

    private static string BuildXML(Dictionary<string, string> listValues)
    {
        XDocument xml = new XDocument();
        XElement root = new XElement("Attributes");
        xml.Add(root);

        foreach (KeyValuePair<string, string> entry in listValues)
        {
            XElement xe = new XElement("Attribute",
            new XAttribute("Name", entry.Key),
            new XAttribute("Value", entry.Value)
            );
            root.Add(xe);
        }

        return xml.ToString();
    }
}
