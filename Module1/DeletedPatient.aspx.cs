using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Module1_DeletedPatient : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Security _Security = new Security();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDeletedPatients();
        if (this.Page.IsPostBack.Equals(false))
        {

            dtpFromDate.Date = DateTime.Now.AddDays(-30);
            dtpToDate.Date = DateTime.Now;

        }
    }

    public void LoadDeletedPatients()
    {
        try
        {

            var _Patient= new Patient();

            _Patient.FromDate = dtpFromDate.Date;
            _Patient.ToDate = dtpToDate.Date;

            ds = _Patient.GetDeletedPatients();


            GvPatient.DataSource = ds.Tables["PatientsDetails"];
            GvPatient.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Initializing Selecting Deleted LoadDeletedPatients Inquiry";
            secs.SaveError();
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

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "context menu on form Loan Repayments  Inquiry";
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
            _Security.ErrorModule = "Adding item on context menu on form  Loan Repayments Inquiry";
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
                    ASPxGridViewExporter.WritePdfToResponse();
                    break;
                case "ExportToXLS":
                    ASPxGridViewExporter.WriteXlsToResponse();
                    break;
                case "ExportToWORD":
                    ASPxGridViewExporter.WriteRtfToResponse();
                    break;
                case "ExportToCSV":
                    ASPxGridViewExporter.WriteCsvToResponse();
                    break;
            }
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Exporting Deleted Loan Applications Inquiry";
            _Security.SaveError();
        }

    }
    protected void cpDeletedPatients_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {
            this.LoadDeletedPatients();

        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on form Loan Repayments Inquiry";
            _Security.SaveError();
        }
    }
}