using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for PatientEnrollMent
/// </summary>
public class PatientEnrollMent
{

    SqlDataAdapter SQAdapter = new SqlDataAdapter();
    DataSet ds = new DataSet();
    Security _Security = new Security();
    public string PatientId { get; set; }
    public string EnrollmentNo { get; set; }
    public DateTime  EnrollmentDate { get; set; }

    public bool SavePatientEnrollMent()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("SpSavePatientEnrollMent", con))
                {
                    ds = new DataSet("PatientEnrollMent");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
                    SqlCommand.Parameters.AddWithValue("@EnrollmentNo", EnrollmentNo);
                    SqlCommand.Parameters.AddWithValue("@EnrollmentDate", EnrollmentDate);
                    SqlCommand.Parameters.AddWithValue("@UserID", "elviskimcheruiyot@gmail.com");
              

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientEnrollMent");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Saving PatientEnrollMent";
            _Security.SaveError();
            return false;
        }
    }
    public DataSet SelectAllPatientEnrollments()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectAllPatientEnrollMent", con))
                {
                    ds = new DataSet("PatientEnrollMent");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                  
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientEnrollMent");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting All PatientEnrollMent";
            _Security.SaveError();
            return null;
        }
    }
    public DataSet SelectPatientEnrollMent()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spSelectPatientEnrollMent", con))
                {
                    ds = new DataSet("PatientEnrollMent");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                   
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
                 
                   
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientEnrollMent");
                    return ds;
                }
            }
        }
        catch (Exception ex)
        {
            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Selecting PatientEnrollMent";
            _Security.SaveError();
            return null;
        }
    }

    public bool DeletePatientEnrollMent()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand("spDeletePatients", con))
                {
                    ds = new DataSet("PatientEnrollMent");
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommand.Parameters.Clear();
                 
                    SqlCommand.Parameters.AddWithValue("@PatientId", PatientId);
             

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SQAdapter.SelectCommand = SqlCommand;
                    SQAdapter.Fill(ds, "PatientEnrollMent");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
        

            _Security.ErrorDesscription = ex.Message;
            _Security.Terminus = Environment.MachineName;
            _Security.ErrorModule = "Deleting PatientEnrollMent";
            _Security.SaveError();
            return false;
        }
    }
    public PatientEnrollMent()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}