using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;

public partial class MedicalDevices_NextOfKinInquiry : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    NextOfKinClass _NextOfKinClass = new NextOfKinClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack.Equals(false))
        {

            LoadNextOfKinInquiry();
        }
    }
    public void LoadNextOfKinInquiry()
    {
        try
        {
           

            ds = _NextOfKinClass.GetAllNextOfKin();
            GVNextOfKinInquiry.DataSource = ds.Tables["NextOfKin"];
            GVNextOfKinInquiry.DataBind();

        }
        catch (Exception ex)
        {
            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = " Initializing Load Data in  NextOfKin Inquiry ";
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
            var ErrorDesscription = ex.Message;
            //_Security.ErrorDesscription = ex.Message;
            //_Security.ErrorModule = "context menu on form Corporation Tax Inquiry";
            //_Security.SaveError();
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
            _Security.ErrorModule = "Adding item on context menu on form  Corporation Tax Inquiry ";
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

            //_Security.ErrorDesscription = ex.Message;
            //_Security.ErrorModule = "Exporting  Corporation Tax Inquiry";
            //_Security.SaveError();
        }

    }
    protected void cpNextOfKinInquiry_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {
            this.LoadNextOfKinInquiry();


        }
        catch (Exception ex)
        {

            //_Security.ErrorDesscription = ex.Message;
            //_Security.ErrorModule = "performing callback on form    Corporation Tax Inquiry";
            //_Security.SaveError();
        }
    }
}

