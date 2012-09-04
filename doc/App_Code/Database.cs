using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Configuration;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    string connectionString;

    public Database()
    {
        string ConnectionString = ConnectionManager.GetDatabaseConnectionString();
        if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentException();
        this.connectionString = ConnectionString;
    }

   
    /// <summary>
    /// Connection string used to connect to the Database
    /// </summary>
    public string ConnectionString
    {
        get { return connectionString; }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Database"/> class with a connection string and a <see cref="DbProviderFactory"/>.
    /// </summary>
    /// <param name="connectionString">The connection string for the database.</param>
    /// <param name="dbProviderFactory">A <see cref="DbProviderFactory"/> object.</param>
    public Database(string ConnectionString)
    {
        if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentException();

        this.connectionString = ConnectionString;
    }


    /// <summary>
    /// <para>Gets the parameter token used to delimit parameters for the SQL Server database.</para>
    /// </summary>
    /// <value>
    /// <para>The '@' symbol.</para>
    /// </value>
    char ParameterToken
    {
        get { return '@'; }
    }

    /// <summary>
    /// Add the '@' symbol to the Parameter Name
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    SqlParameter InjectParamaterToken(SqlParameter parameter)
    {
        parameter.ParameterName = ParameterToken + parameter.ParameterName;
        return parameter;
    }

    /// <summary>
    /// Create a new Open Connection
    /// </summary>
    /// <returns></returns>
    SqlConnection GetNewOpenConnection()
    {
        SqlConnection connection = new SqlConnection(this.connectionString);
        connection.Open();
        return connection;
    }

    /// <summary>
    /// Execute stored procedurea and return a single value
    /// </summary>
    /// <param name="StoredProcedureName"></param>
    /// <param name="ParameterValues"></param>
    /// <returns></returns>
    public virtual object ExecuteScalar(string StoredProcedureName, params object[] ParameterValues)
    {
        using (DbCommand command = GetStoredProcCommand(StoredProcedureName, ParameterValues))
        {
            object o = command.ExecuteScalar();
            command.Connection.Close();             //Added by Pankaj on 26th Jan 2010
            return o;
        }
    }

    public virtual object ExecuteScalarNon(string StoredProcedureName, params object[] ParameterValues)
    {
        using (DbCommand command = GetStoredProcCommand(StoredProcedureName, ParameterValues))
        {
            object o = command.ExecuteNonQuery();
            command.Connection.Close();             //Added by Pankaj on 26th Jan 2010
            return o;
        }
    }

    public virtual object ExecuteScalarNon(string query)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = query;
        command.Connection = GetConnection();
        command.CommandType = CommandType.Text;
        object o = command.ExecuteScalar();
        command.Connection.Close();             //Added by Pankaj on 26th Jan 2010
        return o;
        
    }

    /// <summary>
    /// Execute stored procedure and return a dataset
    /// </summary>
    /// <param name="StoredProcedureName"></param>
    /// <param name="ParameterValues"></param>
    /// <returns></returns>
    public DataSet ExecuteDataSet(string StoredProcedureName, params object[] ParameterValues)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlCommand command = new SqlCommand();
            command = GetStoredProcCommand(StoredProcedureName, ParameterValues);
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                da.Fill(ds);
                command.Connection.Close();
            }
        }
        catch(Exception ex)
        {
        }
        return ds;               
    }

    public SqlDataReader ExecuteDataReader(string StoredProcedureName, params object[] ParameterValues)
    {
        SqlDataReader dr = null;
        try
        {
            SqlCommand command = new SqlCommand();
            command = GetStoredProcCommand(StoredProcedureName, ParameterValues);
            dr = command.ExecuteReader();
        }
        catch (Exception ex)
        {
        }
        return dr;
    }

    //public virtual object ExecuteScalarQuery(string query)
    //{
    //    using (DbCommand command)
    //    {
    //        command.CommandText = query;
    //        object o = command.ExecuteScalar();
    //        command.Connection.Close();
    //        return o;
    //    }
    //}

    public DataSet ExecuteDataSetNonQuery(string Query)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = GetNewOpenConnection();
            command.CommandText = Query;
            command.CommandType = CommandType.Text;
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                da.Fill(ds);
                command.Connection.Close();
            }
        }
        catch
        {
        }
        return ds;        
    }

    public void nonQuery(string Query)
    {
        SqlCommand com = new SqlCommand(Query, GetNewOpenConnection());
        com.ExecuteNonQuery();
        com.Connection.Close();
    }

    /// <summary>
    /// Create a new stored procedure command with an open connection
    /// and add paramter values
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="parameterValues"></param>
    /// <returns></returns>
    SqlCommand GetStoredProcCommand(string storedProcedureName, params object[] parameterValues)
    {
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = storedProcedureName;
        command.Connection = GetNewOpenConnection();
        if (parameterValues != null)
        {
            foreach (SqlParameter p in parameterValues)
            {
                command.Parameters.Add(InjectParamaterToken(p));
            }
        }

        return command;
    }

    public SqlConnection GetConnection()
    {
        return GetNewOpenConnection();
    }
}
