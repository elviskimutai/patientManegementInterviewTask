using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;

public partial class Module1_PatientsBelow15yrs : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Patient _Patient = new Patient();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPatientsInquiry();
        if (this.Page.IsPostBack.Equals(false))
        {

            LoadPatientsInquiry();
        }
    }
    public void LoadPatientsInquiry()
    {
        try
        {


            ds = _Patient.GetPatientsBelow15();
            GVNextOfKinInquiry.DataSource = ds.Tables["PatientsDetails"];
            GVNextOfKinInquiry.DataBind();

        }
        catch (Exception ex)
        {
            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = " Initializing Load Data in  GetPatientsBelow15 Inquiry ";
            _Security.SaveError();
        }
    }

    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        try
        {
            if (e.MenuType == GridViewContextMenuType.Rows)
            {
                var item = e.CreateItem("Export", "Export");
                item.BeginGroup = true;
                e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);

                AddMenuSubItem(item, "PDF", "ExportToPDF", @"Images/ExportToPdf.png", true);
                AddMenuSubItem(item, "XLS", "ExportToXLS", @"Images/ExportToXls.png", true);
                AddMenuSubItem(item, "Word", "ExportToWORD", @"Images/ExportToWord.png", true);
                AddMenuSubItem(item, "CSV", "ExportToCSV", @"Images/ExportToCsv.png", true);
            }
        }
        catch (Exception ex)
        {
            var _Security = new Security();
            var ErrorDesscription = ex.Message;
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "context menu on form Patients Below 15 Inquiry";
            _Security.SaveError();
        }

    }
    private static void AddMenuSubItem(GridViewContextMenuItem parentItem, string text, string name, string imageUrl, bool isPostBack)
    {
        try
        {
            var exportToXlsItem = parentItem.Items.Add(text, name);
            exportToXlsItem.Image.Url = imageUrl;
        }
        catch (Exception ex)
        {
            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Adding item on context menu on form  Patients Below 15 ";
            _Security.SaveError();
        }

    }
    protected void Grid_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
    {
        try
        {
            switch (e.Item.Name)
            {
                case "ExportToPDF":
                    ASPxGridViewExporter1.WritePdfToResponse();
                    break;
                case "ExportToXLS":
                    ASPxGridViewExporter1.WriteXlsToResponse();
                    break;
                case "ExportToWORD":
                    ASPxGridViewExporter1.WriteRtfToResponse();
                    break;
                case "ExportToCSV":
                    ASPxGridViewExporter1.WriteCsvToResponse();
                    break;
            }
        }
        catch (Exception ex)
        {
            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Exporting  Patients Below 15 Inquiry";
            _Security.SaveError();
        }

    }
    protected void cpNextOfKinInquiry_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {
            this.LoadPatientsInquiry();


        }
        catch (Exception ex)
        {
            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on Patients Below 15 Inquiry";
            _Security.SaveError();
        }
    }
}

