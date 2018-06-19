using System;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DevExpress.Web;
using System.Web.Services;

/// <summary>
/// Summary description for NextOfKinClass
/// </summary>
public class NextOfKinClass
{
    SqlDataAdapter SQAdapter = new SqlDataAdapter();
    DataSet ds = new DataSet();
 
    public string PatientId { get; set; }
    public string NextOfKinId { get; set; }
    public string Names { get; set; }
    public DateTime DOB { get; set; }
    Security _Security = new Security();
    public string County { get; set; }
    public string SubCounty { get; set; }
    public string Ward { get; set; }
    public string Village { get; set; }

    public string CellPhone { get; set; }
    public string Email { get; set; }
    public DataSet GetAllNextOfKin()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spGetAllNextOfKin", con))
                {
                    ds = new DataSet("NextOfKin");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "NextOfKin");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting All NextOfKin";
            _Security.SaveError();
            return null;
        }
    }
    public bool SaveNextOfKin()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSaveNextOfKin", con))
                {
                    ds = new DataSet("NextOfKin");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
                    SqlCommand.Parameters.AddWithValue("@NextOfKinId", NextOfKinId);
                    SqlCommand.Parameters.AddWithValue("@Names", Names);
                    SqlCommand.Parameters.AddWithValue("@DOB", DOB);
                    SqlCommand.Parameters.AddWithValue("@County", County);

                    SqlCommand.Parameters.AddWithValue("@SubCounty", SubCounty);
                    SqlCommand.Parameters.AddWithValue("@Ward", Ward);
                    SqlCommand.Parameters.AddWithValue("@Village", Village);
                    SqlCommand.Parameters.AddWithValue("@CellPhone", CellPhone);
                    SqlCommand.Parameters.AddWithValue("@Email", Email);
       
                    SqlCommand.Parameters.AddWithValue("@Terminus", Environment.MachineName);
                    SqlCommand.Parameters.AddWithValue("@UserId", HttpContext.Current.Request.Cookies["UserName"].Value);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "NextOfKin");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Saving NextOfKin";
            _Security.SaveError();
            return false;
        }
    }
    public DataSet SelectAllNextOfKin()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectAllNextOfKin", con))
                {
                    ds = new DataSet("NextOfKin");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "NextOfKin");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting All NextOfKin";
            _Security.SaveError();
            return null;
        }
    }
    public DataSet SelectNextOfKin()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectNextOfKin", con))
                {
                    ds = new DataSet("NextOfKin");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@NextOfKinId", NextOfKinId);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "NextOfKin");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting SelectNextOfKin";
            _Security.SaveError();
            return null;
        }
    }
   
    public bool DeletednextOfKin()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spDeleteNextOfKin", con))
                {
                    ds = new DataSet("DeletednextOfKin");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@NextOfKinId", NextOfKinId);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "DeletednextOfKin");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Deleting Net Of Kin";
            _Security.SaveError();
            return false;
        }
    }

}