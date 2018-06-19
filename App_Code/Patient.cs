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
/// Summary description for Patient
/// </summary>
public class Patient
{
    SqlDataAdapter SQAdapter = new SqlDataAdapter();
    DataSet ds = new DataSet();

    public string PatientId { get; set; }
    public string DeptCode { get; set; }
    public string Names { get; set; }
    public DateTime DOB { get; set; }
    Security _Security = new Security();
    public string County { get; set; }
    public string SubCounty { get; set; }
    public string Ward { get; set; }
    public string Village { get; set; }

    public string CellPhone { get; set; }
    public string Email { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public void LoadManufacurer(ASPxGridLookup searchlookupedit)
    {
        try
        {
            ds = this.GetPatient();
            searchlookupedit.KeyFieldName = "PatientId";
            searchlookupedit.DataSource = ds.Tables["PatientsDetails"];
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
    public DataSet GetPatient()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("GetPatients", con))
                {
                    ds = new DataSet("PatientsDetails");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                   
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientsDetails");
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
    public DataSet GetDeletedPatients()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectDeletedPatients", con))
                {
                    ds = new DataSet("PatientsDetails");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    SqlCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientsDetails");
                    return ds;
                }
            }

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Select  Deleted Patients";
            secs.SaveError();
            return null;
        }
    }
    public bool SaveSavePatientDetails()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSavePatientDetails", con))
                {
                    ds = new DataSet("SavePatientDetails");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
                    SqlCommand.Parameters.AddWithValue("@DeptCode", DeptCode);
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
                    SQAdapter.Fill(ds, "SavePatientDetails");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Saving SavePatientDetails";
            _Security.SaveError();
            return false;
        }
    }
    public DataSet SelectAllPatientDetails()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectAllPatientDetails", con))
                {
                    ds = new DataSet("PatientsDetails");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientsDetails");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting All PatientsDetails";
            _Security.SaveError();
            return null;
        }
    }
    public DataSet SelectSelectPatientDetails()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectPatientDetails", con))
                {
                    ds = new DataSet("PatientsDetails");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientsDetails");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting PatientsDetails";
            _Security.SaveError();
            return null;
        }
    }

    public bool DeletePatientDetails()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spDeletePatientDetails", con))
                {
                    ds = new DataSet("PatientsDetails");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientsDetails");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Deleting Patients Details";
            _Security.SaveError();
            return false;
        }
    }

}