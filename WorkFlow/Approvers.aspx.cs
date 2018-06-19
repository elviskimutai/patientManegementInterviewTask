using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemAdministration_Approvers : System.Web.UI.Page
{
    Approver _Approver = new Approver();
    DataSet ds = new DataSet();
    Security _Security = new Security();
    User _User = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
       
            if (!(HttpContext.Current.Request.Cookies["UserName"].Value.ToString().Equals(string.Empty) || HttpContext.Current.Request.Cookies["UserName"].Value.Equals(null)))
            {
                _Security.Right = "View";
                _Security.SecurityModule = "Approvers";
                if (_Security.ValidatePrivilege())
                {
                LoadModuleName();
                LoadApprovers();
                LoadGridApprovers();
                


                    if (this.Page.IsPostBack.Equals(false))
                    {
                        glModule.Value = "BusinessApplications";
                        glApprovers.Value = "Admin";
                        txtNarration.Text= "New approvals";
                      

                    }

                    ASPxLabel lblCurrentPage = (ASPxLabel)ASPxMenu4.Items[0].FindControl("lblCurrentPage");
                    ASPxLabel lblStatus = (ASPxLabel)ASPxMenu4.Items[1].FindControl("lblStatus");
                    lblCurrentPage.Text = "Approvers  information";



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
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing page components";
            secs.SaveError();
        }
    }
    public void LoadModuleName()
    {
        try
        {
            var _UserRole = new UserRole();
            _UserRole.GetSecurityModules(glModule);


        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing  module name";
            secs.SaveError();

        }
    }
    public void LoadApprovers()
    {
        try
        {
            //var _Approver = new Approver();
            //_Approver.GetApprovers(glApprovers);
            _User.LoadUserNames(glApprovers);
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load approvers";
            secs.SaveError();

        }
    }
    public void LoadGridApprovers()
    {
        try
        {
            var _Approver = new Approver();
            ds = _Approver.SelectAllApprovers();
            GVApprovers.DataSource = ds.Tables["Approvers"];
            GVApprovers.DataBind();

        }
        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load gridview";
            secs.SaveError();

        }
    }
    [WebMethod]
    public static bool SaveApprovers(string Module, string Approver, Int32 ApprovalLevel,bool ApprovalStatus, bool AllowSmsNotification ,string  ApprovalRoute,string Narration)
    {
        try
        {
            var _Approver = new Approver();
            _Approver.Module = Module;
            _Approver.Approver1 = Approver;
            _Approver.ApprovalLevel = ApprovalLevel;
            _Approver.ApprovalStatus = ApprovalStatus;
            _Approver.AllowSmsNotification = AllowSmsNotification;
            _Approver.ApprovalRoute = ApprovalRoute;
            _Approver.Narration = Narration;

            if (_Approver.SaveApprovers())
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
            secs.ErrorModule = "initializing saving approvers";
            secs.SaveError();
            return false;

        }
    }
    [WebMethod]
    public static bool DeleteApprovers(string Module, string Approver, Int32 ApprovalLevel, string ApprovalRoute)
    {
        try
        {
            var _Approver = new Approver();
            _Approver.Module = Module;
            _Approver.Approver1 = Approver;
            _Approver.ApprovalRoute = ApprovalRoute;
            _Approver.ApprovalLevel = ApprovalLevel;
            if (_Approver.DeleteApprovers())
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
            secs.ErrorModule = "initializing Delete approvers";
            secs.SaveError();
            return false;

        }
    }
    [WebMethod]
    public static string SelectApprovers(string Module, string Approver, Int32 ApprovalLevel, string ApprovalRoute)
    {
        try
        {
            DataSet ds1 = new DataSet();
            var _Approver = new Approver();
            _Approver.Module = Module;
            _Approver.Approver1 = Approver;
            _Approver.ApprovalRoute = ApprovalRoute;
            _Approver.ApprovalLevel = ApprovalLevel;
            ds1 = _Approver.SelectApprovers();
            return ds1.GetXml();
        }
        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializing select approvers";
            secs.SaveError();
            return null;
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
                AddMenuSubItem(item, "Csv", "ExportToCSV", @"Images/ExportToCsv.png", true);
                AddMenuSubItem(item, "Excel", "ExportToXLS", @"Images/ExportToXls.png", true);
                AddMenuSubItem(item, "PDF", "ExportToPDF", @"Images/ExportToPdf.png", true);
                AddMenuSubItem(item, "WORD", "ExportToWORD", @"Images/ExportToWord.png", true);

            }
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializing fill context menu";
            secs.SaveError();

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

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializin adding submenu items";
            secs.SaveError();
        }
    }
    protected void Grid_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "initializing method for exporting approvers";
            secs.SaveError();

        }
    }
}