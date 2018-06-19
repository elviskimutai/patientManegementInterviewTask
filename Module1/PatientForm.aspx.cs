using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Module1_PatientForm : System.Web.UI.Page
{
    Patient _Patient = new Patient();
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie UserName = new HttpCookie("UserName");
        UserName.Value = "elviskimcheruiyot@gmail.com";
        Response.Cookies.Add(UserName);
        LoadPatientsDetailsToGrid();
        LoadDepartents();
        if (this.Page.IsPostBack.Equals(false))
        {
            LoadPatientsDetailsToGrid();
        }
    }
    [WebMethod]
    public static bool SavePatientsDetails(string PatientId, String DeptCode, String Names, DateTime DOB, String County, String SubCounty, String Ward, String Village, String CellPhone, String Email)
    {
        try
        {

            var _Patient = new Patient();
            _Patient.PatientId = PatientId;
            _Patient.DeptCode = DeptCode;
            _Patient.Names = Names;
            _Patient.DOB = DOB;
            _Patient.County = County;
            _Patient.SubCounty = SubCounty;
            _Patient.Ward = Ward;
            _Patient.Village = Village;
            _Patient.CellPhone = CellPhone;
            _Patient.Email = Email;


            if (_Patient.SaveSavePatientDetails())
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
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing SavePatientsDetails";
            secs.SaveError();
            return false;
        }
    }
    [WebMethod]
    public static bool DeletedPatientsDetails(string PatientId)
    {
        try
        {
            var _Patient = new Patient();

            _Patient.PatientId = PatientId;



            if (_Patient.DeletePatientDetails())
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
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing DeletedPatientsDetails";
            secs.SaveError();
            return false;
        }
    }


    public void LoadPatientsDetailsToGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            var _Patient = new Patient();
            ds = _Patient.SelectAllPatientDetails();
            GvPatientsDetails.DataSource = ds.Tables["PatientsDetails"];
            GvPatientsDetails.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing Selecting All Patients";
            secs.SaveError();
        }
    }
    [WebMethod]
    public static void SelectPatientsDetails(string PatientId)
    {
        try
        {
            System.Web.HttpContext.Current.Session["PatientId"] = PatientId;


        }
        catch (Exception ex)
        {

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing selecting sacco group";
            _Security.SaveError();
            // return null;
        }
    }
    private void DisableField()
    {
        try
        {
            glDeptCode.ClientEnabled = false;

            txtPatientId.ClientEnabled = false;
            txtNames.ClientEnabled = false;
            txtCounty.ClientEnabled = false;

            txtSubCounty.ClientEnabled = false;
            txtWard.ClientEnabled = false;

            dtpDOB.ClientEnabled = false;
            txtVillage.ClientEnabled = false;
            txtCellPhone.ClientEnabled = false;
            txtEmail.ClientEnabled = false;
        }

        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Disabling fields";
            secs.SaveError();

        }
    }
    protected void cpPatientsDetails_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {

            DataSet ds = new DataSet();
            var _Patient = new Patient();
            _Patient.PatientId = Session["PatientId"].ToString();


            ds = _Patient.SelectSelectPatientDetails();
            DisableField();
            glDeptCode.Value = ds.Tables["PatientsDetails"].Rows[0]["DeptCode"].ToString();
            txtPatientId.Text = ds.Tables["PatientsDetails"].Rows[0]["PatientId"].ToString();

            txtNames.Text = ds.Tables["PatientsDetails"].Rows[0]["Names"].ToString();
            txtCounty.Text = ds.Tables["PatientsDetails"].Rows[0]["County"].ToString();

            txtSubCounty.Text = ds.Tables["PatientsDetails"].Rows[0]["SubCounty"].ToString();

            txtWard.Text = ds.Tables["PatientsDetails"].Rows[0]["Ward"].ToString();
            txtVillage.Text = ds.Tables["PatientsDetails"].Rows[0]["Village"].ToString();
            txtCellPhone.Text = ds.Tables["PatientsDetails"].Rows[0]["CellPhone"].ToString();
            txtEmail.Text = ds.Tables["PatientsDetails"].Rows[0]["Email"].ToString();

            dtpDOB.Value = ds.Tables["PatientsDetails"].Rows[0]["DOB"].ToString();




        }
        catch (Exception ex)
        {
            Security _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on form Perfomance Next of kin";
            _Security.SaveError();
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
    private void LoadDepartents()
    {
        try
        {
            Department _Department = new Department();
            _Department.LoadDepartments(glDeptCode);
        }
        catch (Exception ex)
        {
            Security _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing loading Patients";
            _Security.SaveError();
        }
    }

}