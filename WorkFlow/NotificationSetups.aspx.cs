using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemAdministration_NotificationSetups : System.Web.UI.Page
{
    UserRole _UserRole = new UserRole();
    DataSet ds = new DataSet();
    Security _Security = new Security();
    CostCenter _CostCenter = new CostCenter();
    DistributionList _DistributionList = new DistributionList();
    NotificationSetup _NotificationSetup = new NotificationSetup();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(HttpContext.Current.Request.Cookies["UserName"].Value.ToString().Equals(string.Empty) || HttpContext.Current.Request.Cookies["UserName"].Value.Equals(null)))
            {
                _Security.Right = "View";
                _Security.SecurityModule = "Notification Setup";
                if (_Security.ValidatePrivilege())
                {
                    ASPxLabel lblCurrentPage = (ASPxLabel)ASPxMenu4.Items[0].FindControl("lblCurrentPage");
                    ASPxLabel lblStatus = (ASPxLabel)ASPxMenu4.Items[1].FindControl("lblStatus");
                    lblCurrentPage.Text = "Notification setup Maintenance";
               
                    LoadCostCenter();
                    LoadModule();
                    LoadDistributionlist();
                    LoadNotificationlist();
                    if (this.Page.IsPostBack.Equals(false))
                    {
                         ds = _CostCenter.GetCompanyCostCenters();
                   
                    }
                    LoadDistributionlist();
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
            secs.ErrorModule = " initializing components";
            secs.SaveError();
        }
    }
    public void LoadNotificationlist()
    {
        try
        {
            ds = _NotificationSetup.SelectAllNotificationSetup();
            GVNotificationSetups.DataSource = ds.Tables["NotificationSetup"];
            GVNotificationSetups.DataBind();

        }
        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load gridview";
            secs.SaveError();

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


    public void LoadDistributionlist()
    {
        try
        {
            _DistributionList.CostCenter = this.glCostCenter.Value.ToString();
            _DistributionList.LoadDistributionLists(glDistributionList);
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load security module";
            secs.SaveError();

        }
    }


    public void LoadModule()
    {
        try
        {
      _UserRole.GetSecurityModules(glModule);
        }
        catch (Exception ex)
        {
            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = " initializing load security module";
            secs.SaveError();

        }
    }

    [WebMethod]
    public static bool SavNotificationSetup(string CostCenter, string DistributionList,string Module, Boolean Ad,  Boolean Del, Boolean SendSms, Boolean SendEmail)
    {
        try
        {
            var _NotificationSetup = new NotificationSetup();
            _NotificationSetup.CostCenter = CostCenter;
            _NotificationSetup.DistributionList = DistributionList;
            _NotificationSetup.Module = Module;
            _NotificationSetup.Ad = Ad;
     
            _NotificationSetup.Del = Del;
            _NotificationSetup.SendSms = SendSms;
            _NotificationSetup.SendEmail = SendEmail;
    

            if (_NotificationSetup.SaveNotificationSetup())
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
            secs.ErrorModule = "initializing saving NotificationSetup";
            secs.SaveError();
            return false;

        }
    }
    [WebMethod]
    public static bool DeleteNotificationSetup(string CostCenter, string DistributionList,string Module)
    {
        try
        {
            var NotificationSetup = new NotificationSetup();
            NotificationSetup.CostCenter = CostCenter;
            NotificationSetup.DistributionList = DistributionList;
            NotificationSetup.Module = Module;
            if (NotificationSetup.DeleteNotificationSetup())
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
            secs.ErrorModule = "initializing Delete NotificationSetup";
            secs.SaveError();
            return false;

        }
    }
    protected void cpReminder_Callback(object sender, CallbackEventArgsBase e)
    {
        try
        {
            DataSet ds = new DataSet();
            var _NotificationSetup = new NotificationSetup();
            _NotificationSetup.CostCenter= Session["CostCenter"].ToString();
            _NotificationSetup.DistributionList = Session["DistributionList"].ToString();
            _NotificationSetup.Module = Session["Module"].ToString();

            ds = _NotificationSetup.SelectNotificationSetup();
            DisableField();
            glCostCenter.Value = ds.Tables["NotificationSetup"].Rows[0]["CostCenter"].ToString();
            glDistributionList.Value = ds.Tables["NotificationSetup"].Rows[0]["DistributionList"].ToString();
            glModule.Value = ds.Tables["NotificationSetup"].Rows[0]["Module"].ToString();
            cbAdd.Checked = Convert.ToBoolean(ds.Tables["NotificationSetup"].Rows[0]["Ad"].ToString());
            CBDelete.Checked = Convert.ToBoolean(ds.Tables["NotificationSetup"].Rows[0]["Del"].ToString());
           
            CBSendEmail.Checked = Convert.ToBoolean(ds.Tables["NotificationSetup"].Rows[0]["SendEmail"].ToString());
            CBSendSms.Checked = Convert.ToBoolean(ds.Tables["NotificationSetup"].Rows[0]["SendSms"].ToString());


        }
        catch (Exception ex)
        {

            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "performing callback on form NotificationSetup";
            _Security.SaveError();
        }
    }


    private void DisableField()
    {
        try
        {

            glCostCenter.ClientEnabled = false;
            glDistributionList.ClientEnabled = false;
            glModule.ClientEnabled = false;
            cbAdd.ClientEnabled = false;
            CBDelete.ClientEnabled = false;
          
            CBSendEmail.ClientEnabled = false;
            CBSendSms.ClientEnabled = false;
           
        }

        catch (Exception ex)
        {

            Security secs = new Security();
            secs.ErrorDesscription = ex.Message;
            secs.ErrorModule = "Initializing NotificationSetup";
            secs.SaveError();

        }
    }

    [WebMethod]
    public static void SelectNotificationSetup(string CostCenter,string DistributionList,string Module)
    {
        try
        {

            System.Web.HttpContext.Current.Session["CostCenter"] = CostCenter;
            System.Web.HttpContext.Current.Session["DistributionList"] = DistributionList;
            System.Web.HttpContext.Current.Session["Module"] = Module;

            //return ds.GetXml();
        }
        catch (Exception ex)
        {

            var _Security = new Security();
            _Security.ErrorDesscription = ex.Message;
            _Security.ErrorModule = "Intializing selecting WorkCenters";
            _Security.SaveError();
            // return null;
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
            secs.ErrorModule = "initializing method for exporting userRoles";
            secs.SaveError();

        }
    }
}

