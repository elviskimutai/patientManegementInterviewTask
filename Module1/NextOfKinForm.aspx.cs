using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Kim_NextOfKinForm : System.Web.UI.Page
{
    Patient _Patient = new Patient();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNextOfKinToGrid();
        LoadPatients();
        if (this.Page.IsPostBack.Equals(false))
        {
            LoadNextOfKinToGrid();
        }
    }
    [WebMethod]
    public static bool SaveNextOfKin(string PatientId, String NextOfKinId, String Names, DateTime DOB, String County,String SubCounty,String Ward,String Village, String CellPhone,String Email)
    {
        try
        {

            var _NextOfKinClass = new NextOfKinClass();
            _NextOfKinClass.PatientId = PatientId;
            _NextOfKinClass.NextOfKinId = NextOfKinId;
            _NextOfKinClass.Names = Names;
            _NextOfKinClass.DOB = DOB;
            _NextOfKinClass.County = County;
            _NextOfKinClass.SubCounty = SubCounty;
            _NextOfKinClass.Ward = Ward;
            _NextOfKinClass.Village = Village;
            _NextOfKinClass.CellPhone = CellPhone;
            _NextOfKinClass.Email = Email;


            if (_NextOfKinClass.SaveNextOfKin())
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
            secs.ErrorModule = "Initializing SaveNextOfKin";
            secs.SaveError();
            return false;
        }
    }
    [WebMethod]
    public static bool DeletednextOfKin(string NextOfKinId)
    {
        try
        {
            var _NextOfKinClass = new NextOfKinClass();

            _NextOfKinClass.NextOfKinId = NextOfKinId;
 


            if (_NextOfKinClass.DeletednextOfKin())
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
            secs.ErrorModule = "Initializing DeletednextOfKin";
            secs.SaveError();
            return false;
        }
    }
   

    public void LoadNextOfKinToGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            var _NextOfKinClass = new NextOfKinClass();
            ds = _NextOfKinClass.SelectAllNextOfKin();
            GvNextOfKin.DataSource = ds.Tables["NextOfKin"];
            GvNextOfKin.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing Selecting All Next of Kin";
            secs.SaveError();
        }
    }
    [WebMethod]
    public static void SelectNextOfKin(string NextOfKinId)
    {
        try
        {
            System.Web.HttpContext.Current.Session["NextOfKinId"] = NextOfKinId;
            

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
            glPatient.ClientEnabled = false;

            txtNextOfKinId.ClientEnabled = false;
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
    protected void cpNextOfKin_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {

            DataSet ds = new DataSet();
            var _NextOfKinClass = new NextOfKinClass();
            _NextOfKinClass.NextOfKinId = Session["NextOfKinId"].ToString();
          

            ds = _NextOfKinClass.SelectNextOfKin();
            DisableField();
            glPatient.Value = ds.Tables["NextOfKin"].Rows[0]["PatientId"].ToString();
            txtNextOfKinId.Text = ds.Tables["NextOfKin"].Rows[0]["NextOfKinId"].ToString();

            txtNames.Text = ds.Tables["NextOfKin"].Rows[0]["Names"].ToString();
            txtCounty.Text = ds.Tables["NextOfKin"].Rows[0]["County"].ToString();

            txtSubCounty.Text = ds.Tables["NextOfKin"].Rows[0]["SubCounty"].ToString();

            txtWard.Text = ds.Tables["NextOfKin"].Rows[0]["Ward"].ToString();
            txtVillage.Text = ds.Tables["NextOfKin"].Rows[0]["Village"].ToString();
            txtCellPhone.Text = ds.Tables["NextOfKin"].Rows[0]["CellPhone"].ToString();
            txtEmail.Text = ds.Tables["NextOfKin"].Rows[0]["Email"].ToString();

            dtpDOB.Value = ds.Tables["NextOfKin"].Rows[0]["DOB"].ToString();
           



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
    private void LoadPatients()
    {
        try
        {
            _Patient.LoadManufacurer(glPatient);
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