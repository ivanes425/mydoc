using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for ConnectionManager
/// </summary>
public class ConnectionManager
{
	public static string GetDatabaseConnectionString()
    {
       return ConfigurationManager.ConnectionStrings["fb_amad_conn"].ConnectionString;
    }
}
