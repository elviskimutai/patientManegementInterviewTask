using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// This class handles all iBusinessCloud security operations such as saving errorlogs and validating user rights
/// </summary>
public class Security
{
    DataSet ds;
    SqlDataAdapter SQAdapter = new SqlDataAdapter();
    public DateTime FromDate { get; set; }

    public String Password { get; set; }
    public DateTime ToDate { get; set; }
    #region Properties

    public String UserName { get; set; }
    public String LoginStatus { get; set; }
    public String ErrorDesscription { get; set; }
    public String ErrorModule { get; set; }
    public DateTime ErrorDate { get; set; }
    public String Terminus { get; set; }
    public string Usergroup { get; set; }
    public string SecurityModule { get; set; }
    public string Right { get; set; }
    #endregion
    HttpCookie UserNameCookie = new HttpCookie("UserName");

    public DataSet GetAllAuditTrail()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spGetAllAuditTrail", con))
                {
                    ds = new DataSet("AuditTrail");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "AuditTrail");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {

            var ErrorDesscription = ex.Message;

            return null;
        }
    }
    public bool ValidateUser()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spValidateUser", con))
                {
                    DataSet ds = new DataSet("Users");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@UserName", UserName);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Users");
                    if (ds.Tables["Users"].Rows.Count > 0)
                    {
                        String CipherString = (ds.Tables["Users"].Rows[0]["Password"]).ToString();
                        if (SkypensionCryptoEngine.Decrypt(CipherString, true).Equals(Password))
                        {
                            UserNameCookie.Value = this.UserName;
                            
                            HttpContext.Current.Response.Cookies.Add(UserNameCookie);
                       

                            return true;
                        }
                    }
                    return false;


                }
            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Validating User-Login";
            secs.SaveError();
            throw (ex);
            //return false;
        }
    }
    public bool SaveError()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSaveErrorLogs", con))
                {
                    ds = new DataSet("ErrorLogs");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@Description", ErrorDesscription);
                    SqlCommand.Parameters.AddWithValue("@ErrorModule", ErrorModule);
                    SqlCommand.Parameters.AddWithValue("@Terminus", Terminus);
                    SqlCommand.Parameters.AddWithValue("@UserID", HttpContext.Current.Request.Cookies["UserName"].Value);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "ErrorLogs");
                    return true;
                }
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    public DataSet SelectAuditTrail()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("sprptAuditTrailInquiry", con))
                {
                    ds = new DataSet("AuditTrail");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@CompCode", HttpContext.Current.Request.Cookies["CompCode"].Value);
                    SqlCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    SqlCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    SqlCommand.Parameters.AddWithValue("@UserID", HttpContext.Current.Request.Cookies["UserName"].Value);
                    SqlCommand.Parameters.AddWithValue("@Terminus", Environment.MachineName);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "AuditTrail");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Selecting Audit Trail";
            secs.SaveError();
            return null;
        }
    }
    public DataSet SelectErrorLog()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectErrorLog", con))
                {
                    ds = new DataSet("ErrorLogs");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    SqlCommand.Parameters.AddWithValue("@Todate", ToDate);
                    SqlCommand.Parameters.AddWithValue("@UserID", HttpContext.Current.Request.Cookies["UserName"].Value);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "ErrorLogs");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Select ErrorLog";
            secs.SaveError();
            return null;
        }
    }
    public bool ValidatePrivilege()
    {
        try
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("sp_ValidatePrivilege", con))
                {
                    ds = new DataSet("UserRoles");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@UserGroup", HttpContext.Current.Request.Cookies["UserName"].Value);
                    SqlCommand.Parameters.AddWithValue("@SecurityModule", this.SecurityModule);
                    SqlCommand.Parameters.AddWithValue("@UserID", HttpContext.Current.Request.Cookies["UserName"].Value);
                    SqlCommand.Parameters.AddWithValue("@Terminus", Environment.MachineName);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "UserRoles");
                }
            }
            if (this.Right.Equals("View"))
            {
                for (int i = 0; i <= ds.Tables["UserRoles"].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables["UserRoles"].Rows[0]["View"]).Equals(true))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
            }
            if (this.Right.Equals("Add"))
            {
                for (int i = 0; i <= ds.Tables["UserRoles"].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables["UserRoles"].Rows[0]["Add"]).Equals(true))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if (this.Right.Equals("Edit"))
            {
                for (int i = 0; i <= ds.Tables["UserRoles"].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables["UserRoles"].Rows[0]["Edit"]).Equals(true))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            if (this.Right.Equals("Delete"))
            {
                for (int i = 0; i <= ds.Tables["UserRoles"].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables["UserRoles"].Rows[0]["Delete"]).Equals(true))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if (this.Right.Equals("Export"))
            {
                for (int i = 0; i <= ds.Tables["UserRoles"].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables["UserRoles"].Rows[0]["Export"]).Equals(true))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if (this.Right.Equals("Import"))
            {
                for (int i = 0; i <= ds.Tables["UserRoles"].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables["UserRoles"].Rows[0]["Print"]).Equals(true))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }

            }
            return result;
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Validating privilege";
            secs.SaveError();
            return false;
        }
    }
    public DataSet GetMyViewRoles()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectMyRoles", con))
                {
                    ds = new DataSet("MyRoles");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@UserID", HttpContext.Current.Request.Cookies["UserName"].Value);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "MyRoles");
                    return ds;
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    public string GetCoreModule()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectCoreModule", con))
                {
                    ds = new DataSet("CoreModule");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@UserID", HttpContext.Current.Request.Cookies["UserName"].Value);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "CoreModule");
                    return Convert.ToString(ds.Tables["CoreModule"].Rows[0]["ModuleCode"]);
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

}