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
/// Summary description for Department
/// </summary>
public class Department
{

    SqlDataAdapter SQAdapter = new SqlDataAdapter();
    DataSet ds = new DataSet();

    public string DepartMentName { get; set; }
    public string DeptCode { get; set; }
    public string Description { get; set; }
    
    Security _Security = new Security();
   
    public void LoadDepartments(ASPxGridLookup searchlookupedit)
    {
        try
        {
            ds = this.GetDepartment();
            searchlookupedit.KeyFieldName = "DeptCode";
            searchlookupedit.DataSource = ds.Tables["Departments"];
            searchlookupedit.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Select all permit types";
            secs.SaveError();

        }
    }
    public DataSet GetDepartment()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSGetDepartments", con))
                {
                    ds = new DataSet("Departments");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Departments");
                    return ds;
                }
            }

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Select  PatientId";
            secs.SaveError();
            return null;
        }
    }
    public bool SaveDepartments()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSaveDepartments", con))
                {
                    ds = new DataSet("Departments");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@DeptCode", DeptCode);
                    SqlCommand.Parameters.AddWithValue("@DepartMentName", DepartMentName);
                    SqlCommand.Parameters.AddWithValue("@Description", Description);
                    SqlCommand.Parameters.AddWithValue("@UserId", "elviskimchruiyot@gmail");// HttpContext.Current.Request.Cookies["UserName"].Value);
                    SqlCommand.Parameters.AddWithValue("@Terminus", Environment.MachineName);
                    
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Departments");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Saving SaveDepartments";
            _Security.SaveError();
            return false;
        }
    }
    public DataSet SelectAllDepartments()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectAllDepartments", con))
                {
                    ds = new DataSet("Departments");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Departments");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting All Departments";
            _Security.SaveError();
            return null;
        }
    }
    public DataSet SelectDepartments()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectDepartments", con))
                {
                    ds = new DataSet("Departments");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@DeptCode", DeptCode);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Departments");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting Departments";
            _Security.SaveError();
            return null;
        }
    }

    public bool DeleteDepartments()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spDeleteDepartments", con))
                {
                    ds = new DataSet("Departments");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@DeptCode", DeptCode);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "Departments");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Deleting Departments";
            _Security.SaveError();
            return false;
        }
    }

}