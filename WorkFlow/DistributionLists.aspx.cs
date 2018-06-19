using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DevExpress.Web;
using System.Data;
public partial class DistributionLists : System.Web.UI.Page
{
    Security _Security = new Security();
    DataSet ds = new DataSet();
    CostCenter _CostCenter = new CostCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(HttpContext.Current.Request.Cookies["UserName"].Value.ToString().Equals(string.Empty) || HttpContext.Current.Request.Cookies["UserName"].Value.Equals(null)))
            {
                _Security.Right = "View";
                _Security.SecurityModule = "DistributionLists";
                if (_Security.ValidatePrivilege())
                {
                    ASPxLabel lblCurrentPage = (ASPxLabel)ASPxMenu4.Items[0].FindControl("lblCurrentPage");
                    ASPxLabel lblStatus = (ASPxLabel)ASPxMenu4.Items[1].FindControl("lblStatus");
                    lblCurrentPage.Text = "Distribution Lists Maintenance";
                    lblStatus.Text = " ";
                    LoadCostCenter();
                    LoadDistributionLists();

                }
                else
                {
                    Server.Transfer("/SystemAdministration/Login.aspx");

                }

            }
            else
            {
                Server.Transfer("/SystemAdministration/Login.aspx");
            }
           
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing loading Distribution list page";
            _Security.SaveError();

        }
    }
    [WebMethod]
    public static bool ValidateRight(string Right, string SecurityModule)
    {
        try
        {
            var _Security = new Security();
            _Security.SecurityModule = SecurityModule;
            _Security.Right = Right;
            _Security.Usergroup = HttpContext.Current.Request.Cookies["UserName"].Value;
            return _Security.ValidatePrivilege();
        }
        catch (Exception ex)
        {
            Security MInsureSecurity = new Security();
            MInsureSecurity.ErrorDesscription = ex.Message;
            MInsureSecurity.ErrorModule = "Validating Privilige on Roles";
            MInsureSecurity.SaveError();
            return false;
        }
    }
    public void LoadCostCenter()
    {
        try
        {

            _CostCenter.LoadCompanyCostCenters(glCostCenter);
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load security module";
            secs.SaveError();

        }
    }
    private void LoadDistributionLists()
    {
        try
        {
            var _DistributionList = new DistributionList();
            ds = _DistributionList.SelectAllDistributionLists();
            GvDistributionLists.DataSource = ds.Tables["DistributionList"];
            GvDistributionLists.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Selecting All Distribution Lists";
            secs.SaveError();
        }
    }
    [WebMethod]
    public static bool SaveDistributionList(string CostCenter,string ContactName, string EmailAddress, string MobileNo, string DistributionList)
    {
        try
        {
            var _DistributionList = new DistributionList();
            _DistributionList.CostCenter = CostCenter;
            _DistributionList.ContactName = ContactName;
            _DistributionList.EmailAddress = EmailAddress;
            _DistributionList.MobileNo = MobileNo;
            _DistributionList.DistributionLists = DistributionList;
            if (_DistributionList.SaveDistributionList())
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
            secs.ErrorModule = "Saving Distribution List";
            secs.SaveError();
            return false;

        }
    }
    [WebMethod]
    public static bool DeleteDistributionList(string EmailAddress, string DistributionList)
    {
        try
        {
            var _DistributionList = new DistributionList();
            _DistributionList.EmailAddress = EmailAddress;
            _DistributionList.DistributionLists = DistributionList;
            if (_DistributionList.DeleteDistributionList())
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
            secs.ErrorModule = "Deleting Distribution List";
            secs.SaveError();
            return false;

        }
    }
    [WebMethod]
    public static string SelectDistributionList(string EmailAddress, string DistributionList)
    {
        try
        {
            DataSet ds = new DataSet();
            var _DistributionList = new DistributionList();
            _DistributionList.EmailAddress = EmailAddress;
            _DistributionList.DistributionLists = DistributionList;
            ds = _DistributionList.SelectDistributionList();
            return ds.GetXml();

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Selecting Distribution List";
            secs.SaveError();
            return null;

        }
    }

    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        if (e.MenuType == GridViewContextMenuType.Rows)
        {
            var item = e.CreateItem("Export", "Export");
            item.BeginGroup = true;
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);

            AddMenuSubItem(item, "CSV", "ExportToCSV", @"Images/ExportToCsv.png", true);
            AddMenuSubItem(item, "Excel", "ExportToXLS", @"Images/ExportToXls.png", true);
            AddMenuSubItem(item, "PDF", "ExportToPDF", @"Images/ExportToPdf.png", true);
            AddMenuSubItem(item, "WORD", "ExportToWORD", @"Images/ExportToWord.png", true);
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
            case "ExportToCSV":
                ASPxGridViewExporter1.WriteCsvToResponse();
                break;
            case "ExportToXLS":
                ASPxGridViewExporter1.WriteXlsToResponse();
                break;
            case "ExportToPDF":
                ASPxGridViewExporter1.WritePdfToResponse();
                break;
            case "ExportToWORD":
                ASPxGridViewExporter1.WriteRtfToResponse();
                break;
        }
    }
}