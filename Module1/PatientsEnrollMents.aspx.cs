using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;
using System.Web.Services;

public partial class MedicalDevices_PatientsEnrollMents : System.Web.UI.Page
{
    DataSet ds = new DataSet();
  //  Security _Security = new Security();
    PatientEnrollMent _PatientEnrollMent = new PatientEnrollMent();
    Patient _Patient = new Patient();

    protected void Page_Load(object sender, EventArgs e)
    {
        
       
        LoadPatientID();
        if (this.Page.IsPostBack.Equals(false ))
        {
           
            LoadPatientsEnrollments();
        }
        LoadPatientsEnrollments();
    }


    public void LoadPatientsEnrollments()
    {
        try
        {
            var ds = new DataSet();

            var _PatientEnrollMent = new PatientEnrollMent();
            ds = _PatientEnrollMent.SelectAllPatientEnrollments();
            GvPatientEnrollMent.DataSource = ds.Tables["PatientEnrollMent"];
            GvPatientEnrollMent.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
           // secs.Terminus = HttpContext.Current.Request.Cookies["TerminusCookie"].Value;
            secs.ErrorModule = "Initializing Selecting All PatientEnrollMent";
            secs.SaveError();
        }
    }
    [WebMethod]
    public static bool SavePatientsEnrolment(string PatientId, string EnrollmentNo,  DateTime EnrollmentDate)
    {
        try
        {
            var _PatientEnrollMent = new PatientEnrollMent();

            _PatientEnrollMent.PatientId = PatientId;
            _PatientEnrollMent.EnrollmentNo = EnrollmentNo;
            _PatientEnrollMent.EnrollmentDate = EnrollmentDate;
            




            if (_PatientEnrollMent.SavePatientEnrollMent())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            //secs.Terminus = HttpContext.Current.Request.Cookies["TerminusCookie"].Value;
            secs.ErrorModule = "Initializing Saving PatientEnrollMent";
            secs.SaveError();
            return false;
        }
    }
    [WebMethod]
    public static bool DeletePatientsEnrollments(string PatientId)
    {
        try
        {
            var _PatientEnrollMent = new PatientEnrollMent();
            _PatientEnrollMent.PatientId = PatientId;

            if (_PatientEnrollMent.DeletePatientEnrollMent())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            //secs.Terminus = HttpContext.Current.Request.Cookies["TerminusCookie"].Value;
            secs.ErrorModule = "Initializing Deleting PatientEnrollMent";
            secs.SaveError();
            return false;
        }
    }


    public void LoadPatientID()
    {
        try
        {
            _Patient.LoadManufacurer(glPatientId);

        }
        catch (Exception)
        {

            throw;
        }
    }


    [WebMethod]

    public static void SelectPatientID(string PatientId)
    {
        try
        {
            System.Web.HttpContext.Current.Session["PatientId"] = PatientId;


            //return ds.GetXml();
        }
        catch (Exception ex)
        {

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing selecting Patients Enrollment";
            _Security.SaveError();
            // return null;
        }
    }
    protected void cpPatientEnrollMent_Callback(object sender, CallbackEventArgsBase e)
    {

        try
        {
            DataSet ds = new DataSet();
            var _PatientEnrollMent = new PatientEnrollMent();
            _PatientEnrollMent.PatientId = Session["PatientId"].ToString();
            ds = _PatientEnrollMent.SelectPatientEnrollMent();
            DisableField();

            glPatientId.Value = ds.Tables["PatientEnrollMent"].Rows[0]["PatientId"].ToString();
            txtEnrollmentNo.Text = ds.Tables["PatientEnrollMent"].Rows[0]["EnrollmentNo"].ToString();
            dtpEnrollmentDate.Date = Convert.ToDateTime(ds.Tables["PatientEnrollMent"].Rows[0]["EnrollmentDate"]);
           

        }
        catch (Exception ex)
        {
            var ErrorDesscription = ex.Message;

            //_Security.ErrorDesscription = ex.Message;
            //_Security.ErrorModule = "performing callback on form SubLedger";
            //_Security.SaveError();
        }
    }
    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        if (e.MenuType == GridViewContextMenuType.Rows)
        {
            var item = e.CreateItem("Export", "Export");
            item.BeginGroup = true;
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
            AddMenuSubItem(item, "WORD", "ExportToWord", @"Images/ExportToWord.png", true);
            AddMenuSubItem(item, "PDF", "ExportToPDF", @"Images/ExportToPdf.png", true);
            AddMenuSubItem(item, "EXCEL", "ExportToXLS", @"Images/ExportToXls.png", true);
            AddMenuSubItem(item, "CSV", "ExportToCSV", @"Images/ExportToXls.png", true);
        }
    }

    private void DisableField()
    {
        try
        {


            glPatientId.ClientEnabled = false;
            txtEnrollmentNo.ClientEnabled = false;
            dtpEnrollmentDate.ClientEnabled = false;
           



        }

        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Initializing Investment Portfolio";
            secs.SaveError();

        }
    }


    private static void AddMenuSubItem(GridViewContextMenuItem parentItem, string text, string name, string imageUrl, bool isPostBack)
    {
        var exportToXlsItem = parentItem.Items.Add(text, name);
        exportToXlsItem.Image.Url = imageUrl;
    }
    protected void Grid_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
    {
        switch (e.Item.Name)
        {
            case "ExportToWord":
                ASPxGridViewExporter1.WriteRtfToResponse();
                break;
            case "ExportToPDF":
                ASPxGridViewExporter1.WritePdfToResponse();
                break;
            case "ExportToXLS":
                ASPxGridViewExporter1.WriteXlsToResponse();
                break;
            case "ExportToCSV":
                ASPxGridViewExporter1.WriteCsvToResponse();
                break;

        }
    }


}
