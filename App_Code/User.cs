using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public String UserName { get; set;}
    public String FullNames { get; set; }
    public String Password { get; set; }
    public String Question { get; set; }
    public String Answer { get; set; }
    public String Email { get; set; }
    public String Telephone { get; set; }
    DataSet ds;
    SqlDataAdapter SQAdapter = new SqlDataAdapter();
    public bool SaveUser()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("SaveNewUser", con))
                {
                    ds = new DataSet("Users");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@UserName", UserName);
                    SqlCommand.Parameters.AddWithValue("@FullNames", FullNames);
                    SqlCommand.Parameters.AddWithValue("@Password", Password);
                    SqlCommand.Parameters.AddWithValue("@Question", Question);
                    SqlCommand.Parameters.AddWithValue("@Answer", Answer);
                    SqlCommand.Parameters.AddWithValue("@Email", Email);
                    SqlCommand.Parameters.AddWithValue("@Telephone", Telephone);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Users");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "ESave User";
            secs.SaveError();
            return false;
        }
    }
    public DataSet SelectAllUsers()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectAllUsers", con))
                {
                    ds = new DataSet("Users");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                     if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Users");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            //Security secs = new Security();
            //secs.ErrorDesscription = ex.Message;
            //secs.Terminus = Environment.MachineName;
            //secs.ErrorModule = "Selecting all users";
            //secs.SaveError();
            return null;
        }
    }
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}