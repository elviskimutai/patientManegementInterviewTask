using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DevExpress.Web;
using System.Data;

public partial class SystemAdministration_CoreModules : System.Web.UI.Page
{
    Security _Security = new Security();
    DataSet ds = new DataSet();
    Role _Role = new Role();
    User _User = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(HttpContext.Current.Request.Cookies["UserName"].Value.ToString().Equals(string.Empty) || HttpContext.Current.Request.Cookies["UserName"].Value.Equals(null)))
            {
                _Security.Right = "View";
                _Security.SecurityModule = "Modules";
                if (_Security.ValidatePrivilege())
                {
                    ASPxLabel lblCurrentPage = (ASPxLabel)ASPxMenu4.Items[0].FindControl("lblCurrentPage");
                    ASPxLabel lblStatus = (ASPxLabel)ASPxMenu4.Items[1].FindControl("lblStatus");
                    lblCurrentPage.Text = "Core Module Management";
                    lblStatus.Text = " ";
                    LoadCoreModules();
                    LoadUsers();

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
            _Security.ErrorModule = "Initializing Core Module validation";
            _Security.SaveError();

        }
    }
    private void LoadUsers()
    {
        try
        {
            _User.LoadUserNames(glUserName);
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Initializing loading UserNames";
            _Security.SaveError();
        }
    }
    private void LoadCoreModules()
    {
        try
        {
           
            ds = _Role.SelectAllCoreModule();
            GvCoreModules.DataSource = ds.Tables["ModuleCode"];
            GvCoreModules.DataBind();
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Selecting All core modules";
            secs.SaveError();
        }
    }
    [WebMethod]
    public static bool SaveCoreModule(string ModuleCode, string UserName)
    {
        try
        {
            var _Role = new Role();
            _Role.ModuleCode = ModuleCode;
            _Role.UserName = UserName;
            if (_Role.SaveCoreModule())
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
            secs.ErrorModule = "Saving Core Module";
            secs.SaveError();
            return false;

        }
    }
    public void DisableFields()
    {
        cmbModuleCode.ClientEnabled = false;
        glUserName.ClientEnabled = false;
    }
    [WebMethod]
    public static void SelectCoreModule(string ModuleCode, string UserName)
    {
        try
        {
            System.Web.HttpContext.Current.Session["ModuleCode"] = ModuleCode;
            System.Web.HttpContext.Current.Session["UserName"] = UserName;

        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.Terminus = Environment.MachineName;
            secs.ErrorModule = "Selecting core module";
            secs.SaveError();

        }
    }
    protected void cpCoremodule_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {
            var _Role = new Role();
            _Role.ModuleCode = Session["ModuleCode"].ToString();
            _Role.UserName = Session["UserName"].ToString();
            ds = _Role.SelectCoreModule();
            DisableFields();
            cmbModuleCode.Value = ds.Tables["CoreModule"].Rows[0]["ModuleCode"].ToString();
            glUserName.Value= ds.Tables["CoreModule"].Rows[0]["UserName"].ToString();
        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on form CoreModules";
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